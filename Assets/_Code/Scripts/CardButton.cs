using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    [Header("Card Values")]
    public int id;
    public int damage;

    public TextMeshProUGUI nameTXT;
    public TextMeshProUGUI descriptionTXT;
    public TextMeshProUGUI damageTXT;
    public Image image;
    public CardType cardType;
    public List<Image> imageCardType = new List<Image>();

    public void InitCard(int id)
    {
        var cards = GameManager.ins.cardManager.cards;
        this.id = id;
        this.damage = cards[id].damage;
        this.nameTXT.text = cards[id].name;
        this.descriptionTXT.text = cards[id].description;
        this.damageTXT.text = cards[id].damage.ToString();
        this.image.sprite = cards[id].image;
        this.cardType = cards[id].cardType;

        if (cardType == CardType.Sword || cardType == CardType.Shield || cardType == CardType.Castle)
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
        GameManager.ins.cardClose.InitCardClose(id, gameObject);
    }

    public void UpdateDamage(int value)
    {
        if (value == 1)
        {
            damageTXT.text = value.ToString();
        }
        else
            damageTXT.text = damage.ToString();
    }
}
