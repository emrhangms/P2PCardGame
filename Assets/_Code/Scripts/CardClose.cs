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
    public new TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public TextMeshProUGUI damage;
    public Image image;
    public CardType cardType;
    public List<Image> imageCardType = new List<Image>();

    public Vector3 firstPosition;

    void Start()
    {
        firstPosition = transform.position;
    }

    void Update()
    {

    }

    public void InitCardClose(int id)
    {
        gameObject.SetActive(true);

        var cards = GameManager.ins.cardManager.cards;
        this.id = id;
        this.name.text = cards[id].name;
        this.description.text = cards[id].description;
        this.damage.text = cards[id].damage.ToString();
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
        GameObject cardContainer = GameManager.ins.boardManager.GetCardContainer(id, 0);

        DOTween.Sequence()
            .Append(transform.DOMove(cardContainer.transform.position, 0.5f, false))
            .Join(transform.DOScale(new Vector3(0.28f, 0.28f, 0.28f), 0.5f))
            .AppendCallback(() =>
            {
                GameManager.ins.boardManager.CreateCard(cardContainer, id);
                ResetPositionAndScale();
                gameObject.SetActive(false);
                //TODO : DELETE CARDS FROM DECK
                //TODO : UPDATE CONTAINER DAMAGE
                //TODO : ADD TO CONTAINER LIST
            });
    }

    public void ResetPositionAndScale()
    {
        transform.position = firstPosition;
        transform.localScale = Vector3.one;
    }
}
