using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Vector2 _targetDirection;
    private float _changeDirCD=0;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private SpriteRenderer _spriteRenderer;
    // DIVIDER
    private void Awake()
    {
        _spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();

        Vector2 randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _targetDirection=randomVector;
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        FaceTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            HandleRandomDirectionChange();
        }
    }
    private void HandleRandomDirectionChange(){
        _changeDirCD -= Time.deltaTime;
        if(_changeDirCD<=0){
            _targetDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _changeDirCD = Random.Range(3f,6f);
        }
    }
    private void FaceTowardsTarget()
    {
        // if (_targetDirection.x>0){
            if(_playerAwarenessController.faceToRight){
                _spriteRenderer.flipX = true;
            }else{
                _spriteRenderer.flipX = false;
            }
        // }
        // if (_targetDirection == Vector2.zero)
        // {
        //     return;
        // }

        // Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        // Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        // _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        // if (_targetDirection == Vector2.zero)
        // {
            // _rigidbody.velocity = Vector2.zero;
        // }
        // else
        // {
        if(_playerAwarenessController.AwareOfPlayer){
            // _speed = _speed;
        }else {
            _speed = Random.Range(.3f,1f);
        }
        _rigidbody.velocity = _targetDirection * _speed;
        // }
    }
}
