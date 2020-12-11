using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider hpSlider, spSlider;
    public void Init(PlayerManager playerManager)
    {
        hpSlider.maxValue = playerManager.maxHp;
        spSlider.maxValue = playerManager.maxSp;
        hpSlider.value = playerManager.maxHp;
        spSlider.value = playerManager.maxSp;
    }

    public void UpdateHp(int hp)
    {
        hpSlider.DOValue(hp, 1f, true);
    }

    public void UpdateSp(int sp)
    {
        spSlider.DOValue(sp, 1f, true);
    }
}
