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
            HPBarControl hp = collision.gameObject.GetComponent<HPBarControl>();
            if (hp != null)
            {
                hp.currentHP -= 1f; // Reduce player's HP by 1
            }
        }
    }
}
