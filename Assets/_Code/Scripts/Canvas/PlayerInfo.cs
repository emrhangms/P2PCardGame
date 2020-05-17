using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    public static PlayerInfo ins;

    public string PlayerId;
    public string playerName;
    public string playerPassword;
    public string playerEmail;

    public bool isHost = false;

    private void Awake() => ins = this;

    public void SetPlayer(string id, string name, string email, string password)
    {
        PlayerId = id;
        playerName = name;
        playerEmail = email;
        playerPassword = password;
    }

    public void SetHost(bool host)
    {
        isHost = host;
    }
}
