using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField] private float healAmt=3;
    public void OnCollected(GameObject player){
        // player.GetComponentInChildren<Shooting>().PowerUp(healAmt);
        player.GetComponent<HealthController>().AddHealth(healAmt);
    }
}
