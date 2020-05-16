using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CardClose : MonoBehaviour
{
    [Header("Card Values")]
    public int id;
    public TextMeshProUGUI nameTXT;
    public TextMeshProUGUI descriptionTXT;
    public TextMeshProUGUI damageTXT;
    public Image image;
    public CardType cardType;
    public List<Image> imageCardType = new List<Image>();

    public CardManager cardManager;

    public Vector3 firstPosition;

    void Start()
    {
        cardManager = GameManager.ins.cardManager;
        firstPosition = transform.position;
        transform.localScale = Vector3.zero;
    }

    public void InitCardClose(int id, GameObject selectecCard)
    {
        transform.localScale = Vector3.one;

        cardManager.selectedCard = selectecCard;

        var cards = cardManager.cards;
        this.id = id;
        this.nameTXT.text = cards[id].name;
        this.descriptionTXT.text = cards[id].description;
        this.damageTXT.text = cards[id].damage.ToString();
        this.image.sprite = cards[id].image;
        this.cardType = cards[id].cardType;

        if (cardType == CardType.Sword || cardType == CardType.Shield || cardType == CardType.Castle)
        {
            for (int i = 0; i < imageCardType.Count; i++)
                imageCardType[i].gameObject.SetActive(false);

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

    public void PlaceCard()
    {
        CardContainer cardContainer = GameManager.ins.boardManager.GetCardContainer(id, 0);

        Vector3 cardPosition = cardContainer.container.transform.position;

        DOTween.Sequence()
            .Append(transform.DOMove(cardPosition, 0.5f, false))
            .Join(transform.DOScale(new Vector3(0.28f, 0.28f, 0.28f), 0.5f))
            .AppendCallback(() =>
            {
                GameManager.ins.boardManager.CreateCard(cardContainer, id);

                cardManager.activeDeckCards.Remove(cardManager.selectedCard);
                Destroy(cardManager.selectedCard.gameObject);

                cardManager.selectedCard = null;
            
                ResetCloseCard();
            });
    }

    public void ResetCloseCard()
    {
        transform.position = firstPosition;
        transform.localScale = Vector3.zero;
    }
}
