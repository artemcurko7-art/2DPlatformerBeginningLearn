using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Collided;

    public void Collide() =>
        Collided?.Invoke(this);
}
