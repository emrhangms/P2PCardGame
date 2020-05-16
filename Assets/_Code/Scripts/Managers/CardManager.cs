using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [Header("Active Cards")]
    public GameObject playerDeck;
    public GameObject selectedCard;
    public List<GameObject> activeDeckCards = new List<GameObject>();

    public GameObject PrefCard;

    [Header("Card List")]
    public List<Card> cards = new List<Card>();

    void Start()
    {

    }

    void Update()
    {

    }

    public void CreateCards(int value)
    {
        for (int i = 0; i < value; i++)
        {
            int rand = Random.Range(0, cards.Count);

            GameObject card = Instantiate(PrefCard, transform.position, Quaternion.identity, playerDeck.transform);

            activeDeckCards.Add(card);

            card.GetComponent<CardButton>().InitCard(rand);
        }
    }

    public void RemoveCard()
    {

    }
}

[System.Serializable]
public class Card
{
    public string name;
    [TextArea()]
    public string description;
    public int damage;
    public Sprite image;
    public CardType cardType;
}