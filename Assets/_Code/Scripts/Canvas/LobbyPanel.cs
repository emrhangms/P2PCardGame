using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LobbyPanel : MonoBehaviour
{
    public string hostId;

    [Header("Host")]
    public Text NameHost;
    public Button ReadyButton;
    public Text ReadyText;
    public Image ReadyButtonOverlay;
    public bool ReadyHost = false;

    [Header("Client")]
    public Text NameGuest;
    public Button ReadyButtonGuest;
    public Text ReadyTextGuest;
    public Image ReadyButtonOverlayGuest;
    public bool ReadyGuest = false;

    public void SetHost(string hostId)
    {
        NameHost.text = PlayerInfo.ins.playerName;
    }

    public void SetGuest(string hostId, string hostName)
    {
        NameGuest.text = PlayerInfo.ins.playerName;
        NameHost.text = hostName;
        this.hostId = hostId;
    }

    public void FindGuest()
    {
        StartCoroutine(FindGuestApi());
    }

    public void SetReady()
    {
        if (PlayerInfo.ins.isHost)
        {
            if (ReadyHost)
            {
                ReadyHost = false;

                // SET READY DATABASE

                ReadyButtonOverlay.color = Color.green;

                var colors = ReadyButton.colors;

                colors.normalColor = Color.green;
                colors.highlightedColor = Color.green;
                colors.pressedColor = Color.green;
                colors.selectedColor = Color.green;
                colors.disabledColor = Color.green;

                ReadyText.text = "Hazır!";

                ReadyButton.colors = colors;
            }
            else
            {
                ReadyHost = true;

                // SET NOT READY DATABASE

                ReadyButtonOverlay.color = Color.red;

                var colors = ReadyButton.colors;

                colors.normalColor = Color.red;
                colors.highlightedColor = Color.red;
                colors.pressedColor = Color.red;
                colors.selectedColor = Color.red;
                colors.disabledColor = Color.red;

                ReadyText.text = "Hazır Degil";

                ReadyButton.colors = colors;
            }
        }
        else
        {
            if (ReadyGuest)
            {
                ReadyGuest = false;

                // SET READY DATABASE

                ReadyButtonOverlay.color = Color.green;

                var colors = ReadyButton.colors;

                colors.normalColor = Color.green;
                colors.highlightedColor = Color.green;
                colors.pressedColor = Color.green;
                colors.selectedColor = Color.green;
                colors.disabledColor = Color.green;

                ReadyText.text = "Hazır!";

                ReadyButton.colors = colors;
            }
            else
            {
                ReadyGuest = true;

                // SET NOT READY DATABASE

                ReadyButtonOverlay.color = Color.red;

                var colors = ReadyButton.colors;

                colors.normalColor = Color.red;
                colors.highlightedColor = Color.red;
                colors.pressedColor = Color.red;
                colors.selectedColor = Color.red;
                colors.disabledColor = Color.red;

                ReadyText.text = "Hazır Degil";

                ReadyButton.colors = colors;
            }
        }
    }

    public void ExitLobby()
    {
        //TODO EXİT LOBBY
        if (PlayerInfo.ins.isHost)
        {
            //TODO DELETE ROOM
            PlayerInfo.ins.isHost = false;
            CanvasManager.ins.OpenPanel(PanelNames.PlayerPanel);
        }
    }


    IEnumerator FindGuestApi()
    {
        //TODO Kullanıcı bulma kodu
        UnityWebRequest updateRequest = new UnityWebRequest("asd", "PATCH");
        yield return updateRequest.SendWebRequest();
    }
}
