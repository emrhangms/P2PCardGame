using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;

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
        CanvasManager.ins.lobbyPanel.SetPlayers();
        CanvasManager.ins.OpenPanel(PanelNames.LobbyPanel);
    }

    public void JoinRoom()
    {
        CanvasManager.ins.OpenPanel(PanelNames.LobbyPanel);
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
        //Debug.Log("Get Rooms");

        string Url = $"http://134.122.95.112:3005/rooms";
        Uri uri = new Uri(Url);

        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
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

            if (info[i]["guest"] == "")
                room.GetComponent<PrefRoom>().SetFillness("1");
            else
                room.GetComponent<PrefRoom>().SetFillness("2");

            rooms.Add(room);
        }
    }

    IEnumerator CreateRoomApi()
    {
        string Url = "http://134.122.95.112:3005/rooms";

        WWWForm form = new WWWForm();

        form.AddField("title", PlayerInfo.ins.playerName + "'ın Odası");
        form.AddField("host", PlayerInfo.ins.playerName);
        form.AddField("hostId", PlayerInfo.ins.PlayerId);
        form.AddField("hostReady", "");
        form.AddField("status", "true");
        form.AddField("guest", "");
        form.AddField("guestId", "");
        form.AddField("guestReady", "");


        UnityWebRequest postRequest = UnityWebRequest.Post(Url, form);

        yield return postRequest.SendWebRequest();

        if (postRequest.isNetworkError || postRequest.isHttpError)
        {
            Debug.Log(postRequest.error);
            yield break;
        }
        else
        {
            PlayerInfo.ins.SetHost(true);
            Debug.Log("Room Created");
        }
    }
}