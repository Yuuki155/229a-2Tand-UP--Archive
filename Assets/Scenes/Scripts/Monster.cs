using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Damage;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HPBarControl hp = collision.gameObject.GetComponent<HPBarControl>();
            if (hp != null)
            {
                hp.TakeDamage(Damage); // Reduce player's HP by 1
            }
        }
    }
}
