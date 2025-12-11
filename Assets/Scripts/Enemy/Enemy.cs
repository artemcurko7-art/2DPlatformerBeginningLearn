using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrolling _patrolling;
    [SerializeField] private Following _following;
    [SerializeField] private Died _died;
    [SerializeField] private int _health;
    [SerializeField] private float _speed;

    private void Update()
    {
        if (_patrolling.IsNoticed == false)
            _patrolling.Move(_speed);
        else if (_following.IsReached == false)
            _following.Move(_speed);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        _died.Die(_health);
    }
}
