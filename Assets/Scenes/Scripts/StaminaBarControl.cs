using UnityEngine;
using UnityEngine.UI;

public class StaminaBarControl : MonoBehaviour
{
    public Slider staminaBar;
    public PlayerBasicMovement player;
    public float maxSta;
    public float minSta;
    public float currentStamina;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxSta = player.maxStamina;
        currentStamina = maxSta;
        staminaBar.value = currentStamina / maxSta;
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = currentStamina / maxSta;
        currentStamina = player.currentStamina;
    }
}
