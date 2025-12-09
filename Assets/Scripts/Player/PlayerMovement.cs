using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Ground _ground;
    [SerializeField] private float _speed;

    public void Move(Rigidbody2D rigidbody2D, float direction)
    {
        if (_ground.IsGrounded())
            rigidbody2D.linearVelocity = GetDirection(direction, _speed);
    }

    private Vector2 GetDirection(float direction, float speed) =>
        new Vector2(direction * speed, 0);
}
