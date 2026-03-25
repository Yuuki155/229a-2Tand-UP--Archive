using UnityEngine;

public class Paper : MonoBehaviour
{
    public float spinSpeed = 1.0f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.angularVelocity = Vector3.up * spinSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HPBarControl hp = other.GetComponent<HPBarControl>();

            if (hp != null)
            {
                hp.AddHP(1f);
            }

            Collect();
        }
    }

    void Collect()
    {
        Destroy(gameObject);
    }
}