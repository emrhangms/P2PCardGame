using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverManager : MonoBehaviour
{

    public void GetID(int id)
    {
        if (id == 0)
        {
            Debug.Log("PASS Player 2 : " + id);
            GameManager.ins.Passed_P2 = true;
        }
        else
        {
            //Debug.Log("CARD ID : " + id);
            CardContainer container = GameManager.ins.boardManager.GetCardContainer(id, 1);
            GameManager.ins.boardManager.CreateCard(container, id);
        }
    }

    public void SendID(int id)
    {
        if (id == 0)
        {
            Debug.Log("PASS Player 1");
            GameManager.ins.Passed_P1 = true;
        }
        else
        {
            Debug.Log("CARD ID");
        }
        // TODO : SEND ID 
    }
}
