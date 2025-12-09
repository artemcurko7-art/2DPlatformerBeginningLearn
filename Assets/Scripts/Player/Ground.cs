using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private Transform _groundedPoint;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _distanceRay;

    public bool IsGrounded() =>
        (Physics2D.Raycast(_groundedPoint.position, -Vector2.up, _distanceRay, _groundMask));
}
