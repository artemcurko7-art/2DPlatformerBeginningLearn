using UnityEngine;

public class AidBox : Item
{
    [SerializeField] private int _amountReplenishHealth;

    public void ReplenishHealth(PlayerHealth playerHealth) =>
        playerHealth.Replenish(_amountReplenishHealth);
}
