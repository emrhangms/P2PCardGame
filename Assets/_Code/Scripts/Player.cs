using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int life;
    public new string name;

    public Text nameTXT;

    public Image lifeImg_1;
    public Image lifeImg_2;


    public void SetName()
    {

    }

    public void GetDamage()
    {
        if ((life - 1) == 0)
        {
            lifeImg_1.gameObject.SetActive(false);
            life -= 1;
        }
        else
        {
            life -= 1;
            lifeImg_2.gameObject.SetActive(false);
        }
    }

}
