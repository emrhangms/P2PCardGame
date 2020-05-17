using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;
using UnityEngine.UI;
public class LoginPanel : MonoBehaviour
{
    public List<CanvasGroup> panels = new List<CanvasGroup>();
    public InputField userNameLogin;
    public InputField userNamePassword;
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
        //TODO GİRİŞ İŞLEMLERİ
        Debug.Log("girdi");
        StartCoroutine(GetApi(userNameLogin.text,userNamePassword.text));
        CanvasManager.ins.OpenPanel(PanelNames.PlayerPanel);
    }

    public void OpenCreateAccountPanel()
    {
        //TODO PLAYER YARATMA İŞLEMLERİ
        OpenPanel(1);
    }
    public void CreateAccount()
    {
        //TODO PLAYER YARATMA İŞLEMLERİ
        StartCoroutine(PostApi());
        OpenPanel(0);
    }
    void Update()
    {

    }
    

    // Api functions 
    IEnumerator GetApi(string uname , string password)
    {
        Debug.Log("Login");
        string Url = $"http://134.122.95.112:3005/users/name={uname}/password={password}";
        Uri uri = new Uri(Url);
        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            yield break;
        }
        JSONNode info = JSON.Parse(request.downloadHandler.text);
        

        string name = info["name"];
        Debug.Log("name : " + name);
    }

    IEnumerator PostApi()
    {
        Debug.Log("başladık");
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
        {
            Debug.Log("başarılı");
        }

    }



}
