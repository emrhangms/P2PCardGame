using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    
    public CardManager cardManager;

    public CardClose cardClose;

    public BoardManager boardManager;

    private void Awake()
    {
        ins = this;
    }

    void Start()
    {
        cardManager.CreateCards(8);
        cardClose.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

}
