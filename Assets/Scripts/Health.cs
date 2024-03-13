using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int PlayerHealth { get; private set; } = 100;

    public int MaxHealth { get; private set; } = 100;
    public int MinHealth { get; private set; } = 0;
   
    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage;
        PlayerHealth = Mathf.Clamp(PlayerHealth, MinHealth, MaxHealth);
    }

    public void TakeHeal(int heal)
    {
        PlayerHealth += heal;
        PlayerHealth = Mathf.Clamp(PlayerHealth, MinHealth, MaxHealth);
    }
}
