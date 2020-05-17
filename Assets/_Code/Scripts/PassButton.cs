using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.ins.Passed_P1 = true;
        GameManager.ins.CheckBothPassed();
    }
}
