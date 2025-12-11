using UnityEngine;

public class Died : MonoBehaviour
{
    public void Die(int health)
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
