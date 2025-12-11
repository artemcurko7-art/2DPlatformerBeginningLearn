using Mono.Cecil;
using System.Collections;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _distanceRay;
    [SerializeField] private float _delayAttack;

    public bool CanAttack { get; private set; }

    private void Start()
    {
        CanAttack = true;
    }

    public void Attack()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.right, _distanceRay);

        if (raycastHit2D.transform.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            CanAttack = false;
            StartCoroutine(ProduceDelayTime());
        }

        if (CanAttack)
            StopCoroutine(ProduceDelayTime());
    }

    private IEnumerator ProduceDelayTime()
    {
        var wait = new WaitForSeconds(_delayAttack);

        while (enabled)
        {
            yield return wait;

            CanAttack = true;
        }
    }
}
