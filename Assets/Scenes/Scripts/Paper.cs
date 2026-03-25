using NUnit;
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
            PaperCollected inv = other.GetComponent<PaperCollected>();

            if (hp != null)
            {
                hp.AddHP(1f);
            }

            if (inv != null)
            {
                inv.AddPaper(1);
            }

            Collect();
        }
    }

    void Collect()
    {
        Destroy(gameObject);
    }
}