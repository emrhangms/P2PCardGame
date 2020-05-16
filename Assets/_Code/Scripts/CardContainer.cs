using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardContainer : MonoBehaviour
{
    public int containerDamage;

    public bool weatherEffectIsOn;

    public TextMeshProUGUI containerDamageTXT;

    public GameObject container;

    public GameObject prefCard;

    public GameObject weatherEffect;

    public List<CardButton> activeCards = new List<CardButton>();

    public virtual void Awake()
    {
        prefCard = GameManager.ins.cardManager.PrefCard;
        weatherEffect.SetActive(false);
    }

    public virtual void CreateCard(int id)
    {
        CardButton card = Instantiate(prefCard, container.transform).GetComponent<CardButton>();
        card.InitCard(id);
        activeCards.Add(card);
        UpdateTextDamage();
        GameManager.ins.boardManager.CalculateOvarall();
    }

    public void UpdateTextDamage()
    {
        int damage = 0;

        foreach (var card in activeCards)
        {
            if (weatherEffectIsOn)
                damage += 1;
            else
                damage += int.Parse(card.damageTXT.text);
        }
        containerDamageTXT.text = damage.ToString();
        containerDamage = damage;
    }

    public void SetWeatherEffect(bool weatherEffetvalue)
    {
        weatherEffectIsOn = weatherEffetvalue;
        weatherEffect.SetActive(weatherEffetvalue);
        UpdateTextDamage();
    }

    public virtual void RemoveCards()
    {
        for (int i = activeCards.Count - 1; i >= 0; i--)
        {
            CardButton card = activeCards[i];
            activeCards.Remove(card);
            Destroy(card.gameObject);
        }
    }


}
