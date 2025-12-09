using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent<Coin>(out Coin coin))
        {
            _playerWallet.AddCoin(coin);
            coin.Collide();
        }
    }
}
