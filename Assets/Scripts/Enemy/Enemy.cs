using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrolling _patrolling;
    [SerializeField] private Following _following;
    [SerializeField] private Attack _attack;
    [SerializeField] private float _speed;

    private void Update()
    {
        if (_patrolling.IsNoticed == false)
            _patrolling.Move(_speed);
        else if (_following.IsRanAway == false)
            _following.Move(_speed);
    }
}
