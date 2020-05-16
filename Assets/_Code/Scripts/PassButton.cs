using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassButton : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.ins;
    }

    void Update()
    {

    }

    public void OnClick()
    {
        gameManager.Passed_P1 = true;

        if (gameManager.Passed_P1 == gameManager.Passed_P2)
        {
            gameManager.CalculateResult();
            gameManager.receiverManager.SendID(0);
        }
    }
}
