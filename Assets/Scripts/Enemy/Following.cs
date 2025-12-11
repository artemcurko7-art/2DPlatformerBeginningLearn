using System.Runtime.CompilerServices;
using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] private EnemyTransform _enemy;
    [SerializeField] private Transform _target;
    [SerializeField] private float _maxDistance;

    public bool IsReached { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsReached = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsReached = false;
        }
    }

    public void Move(float speed)
    {
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _target.position, speed * Time.deltaTime);
    }
}
