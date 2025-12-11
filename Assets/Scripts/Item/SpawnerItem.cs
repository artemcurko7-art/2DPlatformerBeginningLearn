using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerItem : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private Transform _spawnerPoint;
    [SerializeField] private float _repeatRate;
    [SerializeField] private int _maxSizePool;
    
    private ObjectPool<Item> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Item>(
            createFunc: () => Instantiate(_item),
            actionOnGet: (item) => ActionOnGet(item),
            actionOnRelease: (item) => ActionOnRelease(item),
            actionOnDestroy: (item) => Destroy(item),
            maxSize: _maxSizePool);
    }

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    private void ActionOnGet(Item item)
    {
        item.transform.position = GetRandomPosition();
        item.gameObject.SetActive(true);
        item.Collided += OnRelease;
    }

    private void ActionOnRelease(Item item)
    {
        item.gameObject.SetActive(false);
    }

    private void OnRelease(Item item)
    {
        _pool.Release(item);
        item.Collided -= OnRelease;
    }

    private void GetCoin()
    {
        _pool.Get();
    }

    private Vector2 GetRandomPosition()
    {
        int indexPosition = Random.Range(0, _spawnerPoint.childCount);
        Vector2 position = _spawnerPoint.GetChild(indexPosition).position;

        return position;
    }

    private IEnumerator SpawnCoin()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_repeatRate);

            GetCoin();

            yield return null;
        }
    }
}
