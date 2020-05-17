using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager ins;

    public LoginPanel loginPanel;

    public PlayerPanel playerPanel;

    public LobbyPanel lobbyPanel;

    public List<CanvasGroup> panels = new List<CanvasGroup>();

    private void Awake() => ins = this;

    void Start()
    {
        OpenPanel(PanelNames.LoginPanel);
    }

    public void OpenPanel(PanelNames panelName)
    {
        ClosePanels();

        panels[(int)panelName].DOFade(1, 0.3f);
        panels[(int)panelName].interactable = true;
        panels[(int)panelName].blocksRaycasts = true;
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

    void Update()
    {

    }

}

public enum PanelNames
{
    LoginPanel,
    PlayerPanel,
    LobbyPanel,
}