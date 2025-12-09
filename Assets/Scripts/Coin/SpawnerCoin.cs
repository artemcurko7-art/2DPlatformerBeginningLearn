using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _spawnerPoint;
    [SerializeField] private float _repeatRate;
    [SerializeField] private int _maxSizePool;
    
    private ObjectPool<Coin> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => Instantiate(_coin),
            actionOnGet: (coin) => ActionOnGet(coin),
            actionOnRelease: (coin) => ActionOnRelease(coin),
            actionOnDestroy: (coin) => Destroy(coin.gameObject),
            maxSize: _maxSizePool);
    }

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    private void ActionOnGet(Coin coin)
    {
        coin.transform.position = GetRandomPosition();
        coin.gameObject.SetActive(true);
        coin.Collided += OnRelease;
    }

    private void ActionOnRelease(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

    private void OnRelease(Coin coin)
    {
        _pool.Release(coin);
        coin.Collided -= OnRelease;
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
