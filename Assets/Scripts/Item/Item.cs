using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public event Action<Item> Collided;

    public void Collide() =>
        Collided?.Invoke(this);
}
