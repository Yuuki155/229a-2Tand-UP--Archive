using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerBasicMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerBasicMovement>();
    }

    bool IsAttacking()
    {
        bool isJumping = !movement.isGrounded;
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && movement.currentStamina > 0f;

        return isJumping || isSprinting;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (IsAttacking())
            {
                Destroy(collision.gameObject);
            }
        }
    }
}