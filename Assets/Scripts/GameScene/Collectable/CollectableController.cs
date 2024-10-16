using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    private ICollectableBehaviour collectableBehaviour;
    
    public void Awake(){
        collectableBehaviour=GetComponent<ICollectableBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        var player = collision.GetComponent<PlayerMovement>();
        if(player){
            collectableBehaviour.OnCollected(player.gameObject);
            Destroy(gameObject);
        }
    }
}
