using UnityEngine;
using UnityEngine.UI;

public class HPBarControl : MonoBehaviour
{
    public Slider hpBar;
    public float maxHP = 5f;
    public float currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        hpBar.value = currentHP / maxHP;
    }

    public void AddHP(float amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0f, maxHP);
    }
}

    