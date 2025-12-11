using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delayAttack;

    private float _elapsedTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player player))
        {
            Attack(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player player))
        {
            _elapsedTime = 0;
        }
    }

    private void Attack(Player player)
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _delayAttack)
        {
            player.TakeDamage(_damage);

            _elapsedTime = 0;
        }
    }
}
