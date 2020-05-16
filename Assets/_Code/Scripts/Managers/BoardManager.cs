using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardManager : MonoBehaviour
{

    [Header("Player 1 Board")]
    public CardContainer swordP_1;
    public CardContainer shieldP_1;
    public CardContainer castleP_1;

    [Header("Player 2 Board")]
    public CardContainer swordP_2;
    public CardContainer shieldP_2;
    public CardContainer castleP_2;

    [Header("Weather Board")]
    public WeatherCardContainer weather;

    [Header("Players Damage")]
    public int damagePlayer_1;
    public int damagePlayer_2;

    public void CreateCard(CardContainer container, int id)
    {
        container.CreateCard(id);
    }

    public void CalculateOvarall()
    {
        damagePlayer_1 = swordP_1.containerDamage + shieldP_1.containerDamage + castleP_1.containerDamage;
        damagePlayer_2 = swordP_2.containerDamage + shieldP_2.containerDamage + castleP_2.containerDamage;
    }

    public CardContainer GetCardContainer(int id, int playerID)
    {
        CardContainer container = swordP_1;

        CardType cardType = GameManager.ins.cardManager.cards[id].cardType;

        if (cardType == CardType.Snow || cardType == CardType.Fog || cardType == CardType.Rain || cardType == CardType.Sunny)
        {
            return weather;
        }

        if (playerID == 0)
        {
            switch (cardType)
            {
                case CardType.Sword:
                    container = swordP_1;
                    break;
                case CardType.Shield:
                    container = shieldP_1;
                    break;
                case CardType.Castle:
                    container = castleP_1;
                    break;
            }
        }
        else if (playerID == 1)
        {
            switch (cardType)
            {
                case CardType.Sword:
                    container = swordP_2;
                    break;
                case CardType.Shield:
                    container = shieldP_2;
                    break;
                case CardType.Castle:
                    container = castleP_2;
                    break;
            }
        }

        return container;
    }

    public void ChangeWeather(CardType cardType)
    {
        if (cardType == CardType.Snow)
        {
            swordP_1.SetWeatherEffect(true);
            swordP_2.SetWeatherEffect(true);
        }
        else if (cardType == CardType.Fog)
        {
            shieldP_1.SetWeatherEffect(true);
            shieldP_2.SetWeatherEffect(true);
        }
        else if (cardType == CardType.Rain)
        {
            castleP_1.SetWeatherEffect(true);
            castleP_2.SetWeatherEffect(true);
        }
        else if (cardType == CardType.Sunny)
        {
            RemoveAllWeatherEffects();
            weather.RemoveCards();
        }
    }

    public void RemoveAllWeatherEffects()
    {
        swordP_1.SetWeatherEffect(false);
        swordP_2.SetWeatherEffect(false);
        shieldP_1.SetWeatherEffect(false);
        shieldP_2.SetWeatherEffect(false);
        castleP_1.SetWeatherEffect(false);
        castleP_2.SetWeatherEffect(false);
    }

}
