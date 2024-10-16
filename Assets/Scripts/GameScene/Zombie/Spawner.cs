using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject zombie2Prefab;
    [SerializeField] private float min;
    [SerializeField] private float max;
    private bool active=true;
    private float timeUntilSpawn;
    public void TurnOn (){
        active=true;
    }
    public void TurnOff (){
        active=false;
    }

    public void Update(){
        timeUntilSpawn-=Time.deltaTime;
        if(timeUntilSpawn<=0&&active){
            // Debug.Log("SPAWNING");
            Instantiate(zombiePrefab, this.transform.position, Quaternion.identity );
            SetTimeUntilSpawn();
        }
    }
    public void SetTimeUntilSpawn(){
        timeUntilSpawn = Random.Range(min,max);
    }
}
