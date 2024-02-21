using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;

    
    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
       
        healthBar.fillAmount = Mathf.Clamp(healthAmount, 0, 100) / 100f;
    }
}
