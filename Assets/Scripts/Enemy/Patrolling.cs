using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private UnitRotation _unitRotation;
    [SerializeField] private EnemyTransform _enemy;
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsNoticed = false;
        }
    }

    public void Move(float speed)
    {
        if (_enemy.transform.position.x == _position.x)
        {
            _position = GetPosition();
            _enemy.transform.rotation = _unitRotation.GetRotation(_direction);
        }

        _enemy.transform.position = new Vector2(Mathf.MoveTowards(_enemy.transform.position.x, _position.x, speed * Time.deltaTime), _enemy.transform.position.y);
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
