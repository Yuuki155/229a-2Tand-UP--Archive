using UnityEngine;

public class PlayerBasicMovement : MonoBehaviour
{
    public float moveForce = 50f;
    public float rotateSpeed = 70f;
    public float maxSprintForce = 100f;

    [Header("Jump Settings")]
    public int maxJumps = 2;
    public float jumpForce = 5f;
    int jumpCount = 0;

    // check speed
    public float currentSpeed;
    public float topSpeed = 0f;

    // speed limit
    public float walkSpeedCap = 6f;
    public float sprintSpeedCap = 10f;

    // stamina
    public float maxStamina = 8f;
    public float staminaDrain = 0.8f;
    public float staminaRegen = 0.6f;

    [Header("Air Control")]
    public float airFloatForce = 10f;
    public int maxAirSprints = 2;

    int airSprintCount = 0;

    public float maxSpeed = 8f;

    public float currentStamina;

    Rigidbody rb;
    public bool isGrounded;
    bool sprintLocked;
    public bool isDead;
    public HPBarControl hPBar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentStamina = maxStamina;
    }

    void Update()
    {
        Rotate();
        Jump();
    }

    void FixedUpdate()
    {
        if (isDead)// Don't move if dead
        {
            this.enabled = false;
        }
        Move();
        Dead();
        // Get horizontal speed (ignores jumping)
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        currentSpeed = flatVel.magnitude;

        // Check for new top speed
        if (currentSpeed > topSpeed)
        {
            topSpeed = currentSpeed;
            Debug.Log("New Top Speed: " + topSpeed);
        }

        // Always show current speed (optional spammy)
        Debug.Log("Current Speed: " + currentSpeed);
    }

    void Move()
    {
        float v = Input.GetAxis("Vertical");

        bool wantsToSprint = Input.GetKey(KeyCode.LeftShift) && v > 0 && !sprintLocked;

        bool canAirSprint = isGrounded || airSprintCount < maxAirSprints;

        bool isSprinting = wantsToSprint && currentStamina > 0f && canAirSprint;

        float force = isSprinting ? maxSprintForce : moveForce;
        float speedCap = isSprinting ? sprintSpeedCap : walkSpeedCap;

        // Apply movement force
        if (v != 0)
        {
            rb.AddForce(transform.forward * v * force);
        }

        // Air float effect
        if (!isGrounded && isSprinting)
        {
            rb.AddForce(Vector3.up * airFloatForce);
        }

        // Count air sprint usage
        if (!isGrounded && isSprinting && wantsToSprint)
        {
            airSprintCount++;
        }

        // Clamp speed
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVel.magnitude > speedCap)
        {
            Vector3 limitedVel = flatVel.normalized * speedCap;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }

        HandleStamina(isSprinting);
    }

    void Rotate()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded || jumpCount < maxJumps)
            {
                // Reset Y velocity for consistent jump height
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

                // Newton's 3rd Law (push ground → go up)
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                jumpCount++;
            }
        }
    }
    public void Dead()
    {
        isDead = hPBar.isDead;
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        airSprintCount = 0;
        jumpCount = 0; // ✅ reset jumps
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
                sprintLocked = true;
            }
        }
        else
        {
            currentStamina += staminaRegen * Time.deltaTime;

            if (currentStamina >= maxStamina)
            {
                currentStamina = maxStamina;
                sprintLocked = false;
            }
        }
    }
}
