using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        if (_target != null)
            transform.position = _target.transform.position + _offset;
    }
}
