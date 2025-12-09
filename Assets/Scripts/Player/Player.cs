using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerJump _playerJump;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private UnitRotation _unitRotation;
    [SerializeField] private InputReader _inputReader;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.Movable += OnMove;
        _inputReader.Jumper += OnJump;
        _inputReader.Idled += _playerAnimation.OnIdledAnimation;
    }

    private void OnDisable()
    {
        _inputReader.Movable -= OnMove;
        _inputReader.Jumper -= OnJump;
        _inputReader.Idled -= _playerAnimation.OnIdledAnimation;
    }

    private void OnMove(float direction)
    {
        _playerMovement.Move(_rigidbody2D, direction);
        transform.rotation = _unitRotation.GetRotation(direction);
        _playerAnimation.OnMovableAnimation();
    }

    private void OnJump() =>
        _playerJump.Jump(_rigidbody2D);
}
