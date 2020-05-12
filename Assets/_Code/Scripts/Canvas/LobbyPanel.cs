using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LobbyPanel : MonoBehaviour
{

    public Button ReadyButton;
    public Text ReadyText;
    public Image ReadyButtonOverlay;

    void Start()
    {

    }

    public void SetReady()
    {
        //TODO SETREADY

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

    public void ExitLobby()
    {
        //TODO EXİT LOBBY
        CanvasManager.ins.OpenPanel(PanelNames.PlayerPanel);
    }

    void Update()
    {

    }

}
