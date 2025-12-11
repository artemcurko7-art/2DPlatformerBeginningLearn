using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private List<Coin> _coins = new List<Coin>();

    public void AddCoin(Coin coin) =>
        _coins.Add(coin);
}