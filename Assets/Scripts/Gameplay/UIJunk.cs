using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIJunk : MonoBehaviour
{
    public Slider hpSlider;

    public void SetUI(DamagePlayer stat)
    {
        hpSlider.maxValue = stat.maxHP;
        hpSlider.value = stat.currentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
