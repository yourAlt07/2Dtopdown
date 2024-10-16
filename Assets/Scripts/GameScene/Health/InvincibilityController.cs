using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController HPController;
    [SerializeField] private float invicDuration;
    // DIVIDER
    private void Awake(){
        HPController = GetComponent<HealthController>();
    }
    public void StartInvincibility(){
        StartCoroutine(InvincibilityCoroutine(invicDuration));
    }
    private IEnumerator InvincibilityCoroutine(float invicibilityDuration){
        HPController.IsInvincible = true;
        yield return new WaitForSeconds(invicibilityDuration);
        HPController.IsInvincible = false;
    }
}
