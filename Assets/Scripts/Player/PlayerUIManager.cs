using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider hpSlider;
    public void Init(PlayerManager playerManager)
    {
        hpSlider.maxValue = playerManager.maxHp;
        hpSlider.value = playerManager.maxHp;
    }

    public void UpdateHp(int hp)
    {
        hpSlider.DOValue(hp, 1f, true);
    }
}
