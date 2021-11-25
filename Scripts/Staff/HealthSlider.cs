using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider healthbar;
    public void SetHealth(float amount)
    {
        healthbar.value = amount;
    }
    public void SetMaxHealth(float amount)
    {
        healthbar.maxValue = amount;
        healthbar.value = amount;
    }
}
