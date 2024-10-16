using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image hpForgroundImg;
    // DIVIDER
    public void UpdateHealthBasr(HealthController hpController){
        hpForgroundImg.fillAmount = hpController.curHP/hpController.maxHP;
    }
}
