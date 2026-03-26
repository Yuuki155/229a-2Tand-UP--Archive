using UnityEngine;

public class Cover : MonoBehaviour
{
    public float spinSpeed = 1.0f;
    Rigidbody rb;
    public GameObject creditText;
    public GameObject hideOtherBars;
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
            Collect();
        }
    }

    void Collect()
    {
        Destroy(gameObject);
        creditText.SetActive(true);
        hideOtherBars.SetActive(false);
    }
}
