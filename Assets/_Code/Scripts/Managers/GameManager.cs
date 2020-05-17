using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;

    public CardManager cardManager;

    public CardClose cardClose;

    public BoardManager boardManager;

    public PlayerManager playerManager;

    public ReceiverManager receiverManager;

    [Header("Panels")]
    public CanvasGroup winPanel;
    public CanvasGroup losePanel;

    [Header("Passed")]
    public bool Passed_P1 = false;
    public bool Passed_P2 = false;

    private void Awake()
    {
        ins = this;
    }

    void Start()
    {
        cardManager.CreateCards(8);
        playerManager.SetNames();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            receiverManager.GetID(0);
            CheckBothPassed();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            int rand = Random.Range(1, cardManager.cards.Count);
            receiverManager.GetID(rand);
        }
    }

    public void CalculateResult()
    {
        boardManager.CalculateOvarall();

        if (boardManager.damagePlayer_1 > boardManager.damagePlayer_2)
        {
            playerManager.player_2.GetDamage();

            Win();
        }
        else
        {
            playerManager.player_1.GetDamage();

            Lose();
        }
        
        cardManager.CreateCards(3);
        RemoveAllCardsAndWeatherEffects();
        ResetPassed();
    }

    public void RemoveAllCardsAndWeatherEffects()
    {
        boardManager.swordP_1.RemoveCards();
        boardManager.swordP_2.RemoveCards();

        boardManager.shieldP_1.RemoveCards();
        boardManager.shieldP_2.RemoveCards();

        boardManager.castleP_1.RemoveCards();
        boardManager.castleP_2.RemoveCards();

        boardManager.weather.RemoveCards();

        boardManager.RemoveAllWeatherEffects();
    }

    public void ResetPassed()
    {
        Passed_P1 = false;
        Passed_P2 = false;
    }

    public void Win()
    {
        winPanel.DOFade(1, 0.3f);
        winPanel.interactable = true;
        winPanel.blocksRaycasts = true;
    }

    public void Lose()
    {
        losePanel.DOFade(1, 0.3f);
        losePanel.interactable = true;
        losePanel.blocksRaycasts = true;
    }

    public void CheckIsOver()
    {
        if (playerManager.player_1.life == 0 || playerManager.player_2.life == 0)
        {
            SceneManager.LoadScene("1 - Login");
        }
    }

    public void CheckBothPassed()
    {
        if (Passed_P1 == Passed_P2)
        {
            CalculateResult();
            receiverManager.SendID(0);
        }
    }

}
