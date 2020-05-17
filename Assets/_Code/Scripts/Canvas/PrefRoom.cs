using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefRoom : MonoBehaviour
{
    [Header("Room Text")]
    public string id;
    public string hostName;

    public Text roomName;
    public Text roomFillness;

    public void SetID(string id)
    {
        this.id = id;
    }

    public void SetHostName(string name)
    {
        hostName = name;
    }

    public void SetName(string roomName)
    {
        this.roomName.text = roomName;
    }

    public void SetFillness(string fillness)
    {
        roomFillness.text = "Doluluk " + fillness + " / 2";
    }

    public void OnClick()
    {
        PlayerPanel.ins.JoinRoom(id, hostName);
    }
}
