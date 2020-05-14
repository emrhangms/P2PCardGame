using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardManager : MonoBehaviour
{

    [Header("Player 1 Board")]
    public GameObject swordP1;
    public GameObject shieldP1;
    public GameObject castleP1;

    [Header("Player 2 Board")]
    public GameObject swordP2;
    public GameObject shieldP2;
    public GameObject castleP2;

    [Header("Weather Board")]
    public GameObject weather;

    public GameObject prefCard;

    void Start()
    {
        prefCard = GameManager.ins.cardManager.PrefCard;
    }

    void Update()
    {

    }

    public void CreateCard(GameObject container, int id)
    {
        GameObject card = Instantiate(prefCard, container.transform);
        card.GetComponent<CardButton>().InitCard(id);
    }

    public GameObject GetCardContainer(int id, int playerID)
    {
        GameObject container = gameObject;

        if (playerID == 0)
        {
            switch (GameManager.ins.cardManager.cards[id].cardType)
            {
                case CardType.Sword:
                    container = swordP1;
                    break;
                case CardType.Shield:
                    container = shieldP1;
                    break;
                case CardType.Castle:
                    container = castleP1;
                    break;
            }
        }
        else
        {
            switch (GameManager.ins.cardManager.cards[id].cardType)
            {
                case CardType.Sword:
                    container = swordP2;
                    break;
                case CardType.Shield:
                    container = shieldP2;
                    break;
                case CardType.Castle:
                    container = castleP2;
                    break;
            }
        }

        return container;
    }

}
