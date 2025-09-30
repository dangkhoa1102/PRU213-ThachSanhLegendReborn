using UnityEngine;

[SerializeField]
public enum DamageType
{
    Physical,
    Fire
}

public struct DamageData
{
    public float Amount;
    public DamageType Type;
    public Vector2 HitDirection;
    public float KnockbackForce;

    public DamageData(float amount, DamageType type, Vector2 direction, float knockbackForce)
    {
        Amount = amount;
        Type = type;
        HitDirection = direction.normalized;
        KnockbackForce = knockbackForce;
    }

}
