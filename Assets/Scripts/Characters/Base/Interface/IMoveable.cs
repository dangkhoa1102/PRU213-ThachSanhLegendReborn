using UnityEngine;

public interface IMoveable
{
    Rigidbody body { get; set; }

    bool isFacingRight { get; set; }

    void Move(Vector2 verlocity);

    void CheckFacingDirection(Vector2 verlocity);

}
