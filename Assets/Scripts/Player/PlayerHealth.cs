using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] public int Health { get; private set; }
    
    private int _maxHealth;

    private void Start()
    {
        _maxHealth = Health;
    }

    public void TakeDamage(int damage) =>
        Health -= damage;

    public void Replenish(int health)
    {
        int calculationHealth = Health + health;

        if (calculationHealth >= _maxHealth)
            Health = _maxHealth;
        else
            Health += calculationHealth;
    }
}
