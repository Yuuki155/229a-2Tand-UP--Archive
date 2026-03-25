using UnityEngine;
using UnityEngine.UI;

public class HPBarControl : MonoBehaviour
{
    public Slider hpBar;
    public PlayerBasicMovement player;
    public float maxHP;
    public float minHP;
    public float currentHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHP = player.maxHP;
        currentHP = maxHP;
        hpBar.value = currentHP / maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = currentHP / maxHP;
        currentHP = player.currentHP;
    }
}
