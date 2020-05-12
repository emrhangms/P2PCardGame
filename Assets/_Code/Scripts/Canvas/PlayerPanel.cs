using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerPanel : MonoBehaviour
{
    public List<CanvasGroup> panels = new List<CanvasGroup>();

    void Start()
    {
        OpenPanel(0);
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

    public void OpenLobby()
    {
        //TODO GİRİŞ İŞLEMLERİ
        CanvasManager.ins.OpenPanel(PanelNames.LobbyPanel);
    }

    public void ExitGame()
    {
        //TODO ÇIKIŞ İŞLEMLERİ
        CanvasManager.ins.OpenPanel(PanelNames.LoginPanel);
    }

    void Update()
    {

    }

}
