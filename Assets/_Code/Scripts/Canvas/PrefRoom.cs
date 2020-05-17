using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefRoom : MonoBehaviour
{
    [Header("Room Text")]
    public string id;
    public Text roomName;
    public Text roomFillness;

    public void SetID(string id)
    {
        this.id = id;
    }

    public void SetName(string name)
    {
        roomName.text = name;
    }

    public void SetFillness(string fillness)
    {
        roomFillness.text = "Doluluk " + fillness + " / 2";
    }

    public void OnClick()
    {
        PlayerPanel.ins.JoinRoom();
    }
}
