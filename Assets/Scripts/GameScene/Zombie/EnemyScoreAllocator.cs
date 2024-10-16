using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreAllocator : MonoBehaviour
{
    [SerializeField] private int killPoint=1;
    private GameManager gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void AllocateScore(){
        gameManager.AddKillCount(killPoint);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
