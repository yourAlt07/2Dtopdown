using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamgedInvincibility : MonoBehaviour
{
    private InvincibilityController invicController;
    [SerializeField] private float invicDuration;
    // DIVIDER
    public void StartInvincibility(){
        invicController.StartInvincibility();
    }
    public void Awake(){
        invicController = GetComponent<InvincibilityController>();
    }
}
