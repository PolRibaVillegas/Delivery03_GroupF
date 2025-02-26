using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public bool IsMoving => _isMoving;
    [SerializeField]
    private float Speed = 5;

    private bool _isMoving;
    PlayerInput _input;
    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;
   
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction = new Vector2(_input.MovementHorizontal, _input.MovementVertical) * Speed;
        _rigidbody.linearVelocity = direction;
        _isMoving = direction.magnitude > 0.01f;

        if (_input.MovementHorizontal > 0) _spriteRenderer.flipX = true;
        else if (_input.MovementHorizontal < 0) _spriteRenderer.flipX = false;
    }
}
