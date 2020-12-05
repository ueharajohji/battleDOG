using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManager : MonoBehaviour
{
    public Slider slider;
    public void Init(EnemyManager enemyManager)
    {
        Debug.Log("entered");
        Debug.Log(enemyManager.maxHp);
        slider.maxValue = enemyManager.maxHp;
        slider.value = enemyManager.maxHp;
    }

    public void UpdateHp(int hp)
    {
        slider.value = hp;
    }
}
