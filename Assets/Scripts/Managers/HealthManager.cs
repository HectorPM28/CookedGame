using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class HealthManager: MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth = 3;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            HealthUIManager.instance.UpdateHeartUI();
        }
    }
    public void RestartHp()
    {
        currentHealth = 3;
        HealthUIManager.instance.UpdateHeartUI();
    }
}
