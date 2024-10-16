using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> collectablePrefabs;

    public void Spawn(Vector2 position){
        int index = Random.Range(0,collectablePrefabs.Count);
        Instantiate(collectablePrefabs[index], position, Quaternion.identity);
    }

}
