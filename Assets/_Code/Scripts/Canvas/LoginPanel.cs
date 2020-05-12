using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoginPanel : MonoBehaviour
{
    public List<CanvasGroup> panels = new List<CanvasGroup>();

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
        CanvasManager.ins.OpenPanel(PanelNames.PlayerPanel);
    }

    public void CreateAccount()
    {
        //TODO PLAYER YARATMA İŞLEMLERİ
        OpenPanel(1);
    }

    void Update()
    {

    }

}
