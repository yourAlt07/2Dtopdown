using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectableDrop : MonoBehaviour
{
    [SerializeField] private float dropChance=.3f;
    private CollectableSpawner colspawner;

    private void Awake(){
        colspawner = FindObjectOfType<CollectableSpawner>();
    }

    public void RandomlyDrop(){
        float random = Random.Range(0f,1f);
        if(dropChance>=random){
        colspawner.Spawn(transform.position);
    }

    }
    
}
