using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _maxDistancePursue;

    public bool IsRanAway { get; private set; }

    public void Move(float speed)
    {
        if (Vector3.Distance(_target.position, transform.position) <= _maxDistancePursue)
        {
            IsRanAway = true;
            return;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
            IsRanAway = false;
        }
    }
}
