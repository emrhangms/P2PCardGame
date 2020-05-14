using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    [Header("Card Values")]
    public int id;
    public new TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public TextMeshProUGUI damage;
    public Image image;
    public CardType cardType;
    public List<Image> imageCardType = new List<Image>();

    //TODO : CREATE INACTIVE CARDS

    void Start()
    {
    }

    void Update()
    {

    }

    public void InitCard(int id)
    {
        var cards = GameManager.ins.cardManager.cards;
        this.id = id;
        this.name.text = cards[id].name;
        this.description.text = cards[id].description;
        this.damage.text = cards[id].damage.ToString();
        this.image.sprite = cards[id].image;
        this.cardType = cards[id].cardType;

        if (cardType == CardType.Sword || cardType == CardType.Shield ||cardType == CardType.Castle)
        {
            switch (cardType)
            {
                case CardType.Sword:
                    imageCardType[0].gameObject.SetActive(true);
                    break;
                case CardType.Shield:
                    imageCardType[1].gameObject.SetActive(true);
                    break;
                case CardType.Castle:
                    imageCardType[2].gameObject.SetActive(true);
                    break;
            }
        }
    }

    public void OnClick()
    {
        GameManager.ins.cardClose.InitCardClose(id);
    }
}
