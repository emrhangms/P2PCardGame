using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LobbyPanel : MonoBehaviour
{
    [Header("Host")]
    public Text NameHost;
    public Button ReadyButton;
    public Text ReadyText;
    public Image ReadyButtonOverlay;
    public bool ReadyHost;

    [Header("Client")]
    public Text NameGuest;
    public Button ReadyButtonGuest;
    public Text ReadyTextGuest;
    public Image ReadyButtonOverlayGuest;
    public bool ReadyGuest;

    public void SetPlayers()
    {
        if (PlayerInfo.ins.isHost)
        {
            NameHost.text = PlayerInfo.ins.playerName;
        }
        else
        {
            Debug.Log("sa");
            NameGuest.text = PlayerInfo.ins.playerName;
            //TODO GUEST PLAYER GETS HOST NAME
        }
    }

    public void SetReady()
    {
        if (PlayerInfo.ins.isHost)
        {
            if (ReadyHost)
            {
                ReadyHost = false;

                //TODO SET READY DATABASE

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

                //TODO SET NOT READY DATABASE

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
            //TODO : GUEST READY
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
}
