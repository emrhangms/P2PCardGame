using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    public List<CanvasGroup> panels = new List<CanvasGroup>();
    [Header("Login Fields")]
    public InputField loginUserName;
    public InputField userNamePassword;

    [Header("Sign In Fields")]
    public InputField signUserName;
    public InputField signPassword;
    public InputField signEmail;


    void Start()
    {
        OpenPanel(0);
    }

    public void OpenPanel(int PanelID)
    {
        ClosePanels();

        panels[PanelID].DOFade(1, 0.5f);
        panels[PanelID].interactable = true;
        panels[PanelID].blocksRaycasts = true;
    }

    public void ClosePanels()
    {
        foreach (var panel in panels)
        {
            panel.DOFade(0, 0.5f);
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
    }

    public void Login()
    {
        StartCoroutine(GetApi(loginUserName.text, userNamePassword.text));
    }

    public void OpenCreateAccountPanel()
    {
        OpenPanel(1);
    }
    public void CreateAccount()
    {
        //TODO PLAYER YARATMA İŞLEMLERİ
        StartCoroutine(PostApi());
        OpenPanel(0);
    }

    IEnumerator GetApi(string uname, string password)
    {
        string Url = $"http://134.122.95.112:3005/users/name={uname}/password={password}";

        Uri uri = new Uri(Url);
        UnityWebRequest request = UnityWebRequest.Get(uri);

        yield return request.SendWebRequest();

        JSONNode info = JSON.Parse(request.downloadHandler.text);

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            yield break;
        }
        else
        {
            PlayerInfo.ins.SetPlayer(info[0]["_id"], info[0]["name"], info[0]["email"], info[0]["password"]);
            CanvasManager.ins.OpenPanel(PanelNames.PlayerPanel);
            CanvasManager.ins.playerPanel.SetPlayerName();
        }
    }

    IEnumerator PostApi()
    {
        string Url = "http://134.122.95.112:3005/users";

        WWWForm form = new WWWForm();

        form.AddField("name", signUserName.text);
        form.AddField("email", signEmail.text);
        form.AddField("password", signPassword.text);

        UnityWebRequest postRequest = UnityWebRequest.Post(Url, form);
        yield return postRequest.SendWebRequest();

        if (postRequest.isNetworkError || postRequest.isHttpError)
        {
            Debug.Log(postRequest.error);
            yield break;
        }
        else
            Debug.Log("Oyuncu Yaratıldı");
    }
}
