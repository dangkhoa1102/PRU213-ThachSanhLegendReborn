using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageAble, IMoveable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 10f;
    public float CurrentHealth { get; set; }
    public Rigidbody body { get; set; }
    public bool isFacingRight { get; set; } = true;

    void Start()
    {
        CurrentHealth = MaxHealth;

        body = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    #region Movement Functions
    public void CheckFacingDirection(Vector2 velocity)
    {
        if (isFacingRight && velocity.x < 0f)
        {
            Flip();
        }
        else if (!isFacingRight && velocity.x > 0f)
        {
            Flip();
        }
    }

    public void Move(Vector2 verlocity)
    {

    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    #endregion

    #region Health Functions
    public void Damage(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }
    public void Heal(float healAmount)
    {

    }
    public void Die()
    {

    }
    #endregion

    #region Animation Trigger Events
    public enum states
    {
        Attack,
        Hit,
        Death
    }

    public void TriggerEvent(states triggerState)
    {

        //TODO: Implement once statemachine is in place
    }

    public enum TriggerEventType
    {
        somethinghere
    }
    #endregion
}