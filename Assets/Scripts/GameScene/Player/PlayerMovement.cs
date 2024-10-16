using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCam;
    private Vector2 mousePos;

    [SerializeField] private float _speed=2f;
    [SerializeField] private float _smoothness=.05f;
    [SerializeField] private GameObject graphics;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    
    // DIVIDER
    private void Awake()
    {  
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
        _animator = graphics.GetComponent<Animator>();

    }
    private void SetAnimation(){
        bool isMoving = _movementInput!=Vector2.zero;
        _animator.SetBool("IsMoving",isMoving);
    }
    private void FixedUpdate()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        SetPlayerVelocity();
        // _spriteRenderer.flipX = _rigidbody.velocity.x <0f;
        if(this.transform.position.x>mousePos.x){
            _spriteRenderer.flipX = true;
        }else{
            _spriteRenderer.flipX = false;
        }
        SetAnimation();

        
    }
    private void SetPlayerVelocity(){
            _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            _smoothness);

        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }
    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}