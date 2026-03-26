using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPBarControl : MonoBehaviour
{
    public Slider hpBar;
    public GameObject text;
    public GameObject backGround;

    public float maxHP = 5f;
    public float currentHP;

    [Header("Invincibility")]
    public float invincibleTime = 1.0f;
    bool isInvincible = false;
    public bool isDead = false;

    PlayerBasicMovement player;

    void Start()
    {
        currentHP = maxHP;
        player = GetComponent<PlayerBasicMovement>();
    }
    public void AddHP(float amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0f, maxHP);
    }

    void Update()
    {
        hpBar.value = currentHP / maxHP;
        if(currentHP <= 0f)
        {
            Debug.Log("Player has died!");
            isDead = true;
            text.SetActive(true);
            backGround.SetActive(true);
        }
    }

    public void TakeDamage(float amount)
    {
        // 🛑 Ignore damage if invincible OR sprinting
        if (isInvincible || IsSprinting())
            return;

        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0f, maxHP);

        StartCoroutine(InvincibilityCoroutine());
    }

    bool IsSprinting()
    {
        return Input.GetKey(KeyCode.LeftShift) && player.currentStamina > 0f;
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}