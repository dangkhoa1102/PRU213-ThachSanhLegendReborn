using UnityEngine;

public interface IDamageAble
{
    
    void Damage(float damage, Vector3 hitPoint, Vector3 hitDirection);
    void Heal(float healAmount);
    void Die();
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }


}
