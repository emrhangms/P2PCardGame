using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;

    public CardManager cardManager;

    public CardClose cardClose;

    public BoardManager boardManager;

    public PlayerManager playerManager;

    public ReceiverManager receiverManager;

    public bool Passed_P1 = false;
    public bool Passed_P2 = false;

    private void Awake()
    {
        ins = this;
    }

    void Start()
    {
        cardManager.CreateCards(8);
        //TODO : SET NAMES
        playerManager.SetNames();
    }

    public void CalculateResult()
    {
        boardManager.CalculateOvarall();
        if (boardManager.damagePlayer_1 > boardManager.damagePlayer_2)
        {
            playerManager.player_2.GetDamage();

            if (playerManager.player_2.life == 0)
            {
                Win();
            }
            else
            {
                Debug.Log("WIN ROUND");
                //TODO : WIN ROUND
            }
        }
        else
        {
            playerManager.player_1.GetDamage();

            if (playerManager.player_1.life == 0)
            {
                Lose();
            }
            else
            {
                Debug.Log("LOSE ROUND");
                //TODO : LOSE ROUND
            }
        }

        RemoveAllCards();
        ResetPassed();
    }

    public void RemoveAllCards()
    {
        boardManager.swordP_1.RemoveCards();
        boardManager.swordP_2.RemoveCards();

        boardManager.shieldP_1.RemoveCards();
        boardManager.shieldP_2.RemoveCards();

        boardManager.castleP_1.RemoveCards();
        boardManager.castleP_2.RemoveCards();
        boardManager.RemoveAllWeatherEffects();
    }

    public void ResetPassed()
    {
        Passed_P1 = false;
        Passed_P2 = false;
    }

    public void Win()
    {
        Debug.Log("YOU WIN");
        //TODO : Exit
    }

    public void Lose()
    {
        Debug.Log("YOU LOSE");
        //TODO : Exit
    }

}
