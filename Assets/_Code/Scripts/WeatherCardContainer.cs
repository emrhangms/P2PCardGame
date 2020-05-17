using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherCardContainer : CardContainer
{
    public override void Awake()
    {
        prefCard = GameManager.ins.cardManager.PrefCard;
    }

    public override void CreateCard(int id)
    {
        CardButton card = Instantiate(prefCard, container.transform).GetComponent<CardButton>();
        card.InitCard(id);
        activeCards.Add(card);
        UpdateWeather(card.cardType);
    }

    public void UpdateWeather(CardType cardType)
    {
        GameManager.ins.boardManager.ChangeWeather(cardType);
    }
   
}
