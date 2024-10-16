using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    [SerializeField] public bool AwareOfPlayer { get; private set; }
    public bool faceToRight { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;
    private Transform _player;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
        if(FindObjectOfType<PlayerMovement>()){
            _player = FindObjectOfType<PlayerMovement>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_player){
            Vector2 enemyToPlayerVector = _player.position - this.transform.position;
            DirectionToPlayer = enemyToPlayerVector.normalized;

            if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
            {
                AwareOfPlayer = true;
                if(DirectionToPlayer.x>0){
                    faceToRight=true;
                }else{
                    faceToRight=false;
                }
            }
            else
            {
                AwareOfPlayer = false;
            }
        }else{
            if(GetComponent<Rigidbody2D>().velocity.x>0){
                faceToRight=true;
            }else{
                faceToRight=false;
            }
        }
    
    }
}
