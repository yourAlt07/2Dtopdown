using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoostCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField] private float duration=3f;
    public void OnCollected(GameObject player){
        player.GetComponentInChildren<Shooting>().PowerUp(duration);
    }
}
