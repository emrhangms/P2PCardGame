using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using BayatGames.Serialization.Formatters.Json;
using System.Diagnostics;
using Models;
using System.Threading;

public class PlayerPanel : MonoBehaviour
{
    public static PlayerPanel ins;
    [Header("Player")]
    public Text playerNameTXT;

    [Header("Panels")]
    public List<CanvasGroup> panels = new List<CanvasGroup>();

    [Header("Prefabs")]
    public GameObject PrefRoom;

    public GameObject roomParent;

    [Header("Room List")]
    public List<GameObject> rooms = new List<GameObject>();

    private void Awake() => ins = this;
    public GameObject client;
    void Start()
    {
        OpenPanel(0);
        GetRooms();
    }

    public void OpenPanel(int PanelID)
    {
        ClosePanels();

        panels[PanelID].DOFade(1, 0.3f);
        panels[PanelID].interactable = true;
        panels[PanelID].blocksRaycasts = true;
    }

    public void ClosePanels()
    {
        foreach (var panel in panels)
        {
            panel.DOFade(0, 0.3f);
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
    }

    public void CreateRoom()
    {
        StartCoroutine(CreateRoomApi());
    }

    public void JoinRoom(string roomID, string hostName)
    {
        StartCoroutine(JoinRoomApi(roomID, hostName));
    }

    public void ExitGame()
    {
        //TODO : ÇIKIŞ İŞLEMLERİ
        CanvasManager.ins.OpenPanel(PanelNames.LoginPanel);
    }

    public void GetRooms()
    {
        StartCoroutine(GetRoomsApi());
    }

    public void SetPlayerName()
    {
        playerNameTXT.text = PlayerInfo.ins.playerName;
    }

    IEnumerator GetRoomsApi()
    {
        string Url = $"http://134.122.95.112:3005/rooms";
        Uri uri = new Uri(Url);

        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            UnityEngine.Debug.Log(request.error);
            yield break;
        }

        JSONNode info = JSON.Parse(request.downloadHandler.text);

        for (int i = rooms.Count - 1; i >= 0; i--)
        {
            //Remove Rooms
            Destroy(rooms[i].gameObject);
            rooms.Remove(rooms[i]);
        }

        for (int i = 0; i < info.Count; i++)
        {
            //Add Rooms
            GameObject room = Instantiate(PrefRoom, roomParent.transform);
            room.GetComponent<PrefRoom>().SetName(info[i]["title"]);
            room.GetComponent<PrefRoom>().SetHostName(info[i]["host"]);
            room.GetComponent<PrefRoom>().SetID(info[i]["_id"]);

            if (info[i]["guest"] == "")
                room.GetComponent<PrefRoom>().SetFillness("1");
            else
            {
                room.GetComponent<PrefRoom>().SetFillness("2");
                room.GetComponent<Button>().interactable = false;
            }

            rooms.Add(room);
        }
    }

    IEnumerator CreateRoomApi()
    {
       // StartClient();
        Thread.Sleep(100);

        string Url = "http://134.122.95.112:3005/rooms";

        WWWForm form = new WWWForm();

        form.AddField("title", PlayerInfo.ins.playerName + "'ın Odası");
        form.AddField("host", PlayerInfo.ins.playerName);
        form.AddField("hostId", PlayerInfo.ins.PlayerId);
        form.AddField("status", "true");
        form.AddField("guest", "");
        form.AddField("guestId", "");

        UnityWebRequest postRequest = UnityWebRequest.Post(Url, form);

        yield return postRequest.SendWebRequest();
        JSONNode info = JSON.Parse(postRequest.downloadHandler.text);

        if (postRequest.isNetworkError || postRequest.isHttpError)
        {
            UnityEngine.Debug.Log(postRequest.error);
            yield break;
        }
        else
        {
            UnityEngine.Debug.Log("dasasdasdsad" + info["_id"]);
            // Request gönderme yeni sistem
            Request request = new Request() { Action = "CreateGameLobby", User = PlayerInfo.ins.PlayerId, Payload = info["_id"]};
            Client.ins.SendRequest(request);

            UnityEngine.Debug.Log("Room Created"); 
            PlayerInfo.ins.SetHost(true);
            CanvasManager.ins.lobbyPanel.SetHost(PlayerInfo.ins.PlayerId);
            CanvasManager.ins.OpenPanel(PanelNames.LobbyPanel);
        }
    }

    IEnumerator JoinRoomApi(string roomID, string hostName)
    {
        //StartClient();
        Thread.Sleep(100);
        string Url = $"http://134.122.95.112:3005/rooms/id={roomID}";

        Guest guest = new Guest() { guest = PlayerInfo.ins.playerName, guestId = PlayerInfo.ins.PlayerId };
        string reqMessage = JsonFormatter.SerializeObject(guest);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(reqMessage);

        UnityWebRequest updateRequest = new UnityWebRequest(Url, "PATCH");
        updateRequest.SetRequestHeader("content-Type", "application/json");
        updateRequest.method = "PATCH";
        updateRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(bytes);

        //Debug.Log("sadsada" + updateRequest.uploadedBytes);
        yield return updateRequest.SendWebRequest();
        

        if (updateRequest.isNetworkError || updateRequest.isHttpError)
        {
            UnityEngine.Debug.Log(updateRequest.error);
            yield break;
        }
        else
        {
            // Request gönderme yeni sistem
            Request request = new Request() {Action = "JoinGameLobby",User=PlayerInfo.ins.PlayerId ,Payload = roomID };
            Client.ins.SendRequest(request);

            PlayerInfo.ins.SetHost(false);
            CanvasManager.ins.lobbyPanel.SetGuest(roomID, hostName);
            CanvasManager.ins.OpenPanel(PanelNames.LobbyPanel);
        }
    }

    void StartClient()
    {
        // ToDO burası taşınabilir.
        Instantiate(client);
    }
}

class Guest
{
    public string guest;
    public string guestId;
}
