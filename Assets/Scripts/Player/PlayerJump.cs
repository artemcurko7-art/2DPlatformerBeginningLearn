using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Ground _ground;
    [SerializeField] private float _jumpForce;

    public void Jump(Rigidbody2D rigidbody2D)
    {
        if (_ground.IsGrounded())
            rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
