using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public Player player_1;
    public Player player_2;

    public void SetNames()
    {
        player_1.SetName();
        player_2.SetName();
    }
}
