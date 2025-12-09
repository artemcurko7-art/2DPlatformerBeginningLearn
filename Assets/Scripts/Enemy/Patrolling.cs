using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private UnitRotation _unitRotation;
    [SerializeField] private Transform _enemy;
    [SerializeField] private Transform _targetPoint;  

    private Vector3 _position;
    private int _direction;

    public bool IsNoticed { get; private set; }

    private void Start()
    {
        _position = GetPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsNoticed = true;
        }
    }

    public void Move(float speed)
    {
        if (transform.position == _position)
        {
            _position = GetPosition();
            _enemy.transform.rotation = _unitRotation.GetRotation(_direction);
        }

        _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position, _position, speed * Time.deltaTime);
    }

    private Vector3 GetPosition()
    {
        _direction++;

        if (_direction == _targetPoint.childCount)
            _direction = 0;

        Vector3 posiiton = _targetPoint.GetChild(_direction).position;

        return posiiton;
    }
}
