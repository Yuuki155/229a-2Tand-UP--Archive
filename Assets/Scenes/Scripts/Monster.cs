using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerBasicMovement player = collision.gameObject.GetComponent<PlayerBasicMovement>();
            if (player != null)
            {
                player.currentHP -= 20f; // Reduce player's HP by 20
            }
        }
    }
}
