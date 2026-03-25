using UnityEngine;

public class PlayerBasicMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float rotateSpeed = 120f;
    public float jumpForce = 12f;
    public float maxSprintSpeed = 8f;
    public float acceleration = 3f;

    public float maxHP = 100f;
    public float currentHP;

    public float maxStamina = 5f;
    public float staminaDrain = 1f;
    public float staminaRegen = 0.8f;

    float currentSpeed;
    public float currentStamina;

    Rigidbody rb;
    bool isGrounded;
    bool sprintLocked;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = moveSpeed;
        currentHP = maxHP;
        currentStamina = maxStamina;
    }

    void Update()
    {
        Rotate();
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float v = Input.GetAxis("Vertical");
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && currentStamina > 0f && v > 0 && !sprintLocked;
        // Target speed
        float targetSpeed = isSprinting ? maxSprintSpeed : moveSpeed;

        // Smooth acceleration toward target speed
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        Vector3 forwardMove = transform.forward * v * currentSpeed;
        rb.linearVelocity = new Vector3(forwardMove.x, rb.linearVelocity.y, forwardMove.z);

        HandleStamina(isSprinting);
    }

    void Rotate()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    void HandleStamina(bool isSprinting)
    {
        if (isSprinting)
        {
            currentStamina -= staminaDrain * Time.deltaTime;

            if (currentStamina <= 0f)
            {
                currentStamina = 0f;
                sprintLocked = true; // Lock sprint
            }
        }
        else
        {
            currentStamina += staminaRegen * Time.deltaTime;

            if (currentStamina >= maxStamina)
            {
                currentStamina = maxStamina;
                sprintLocked = false; // Unlock sprint when FULL
            }
        }
    }
}
