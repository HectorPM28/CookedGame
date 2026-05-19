using UnityEngine;

public class HealthUIManager : MonoBehaviour
{
    public static HealthUIManager instance;
    private int currentHp;

    [SerializeField]
    private GameObject[] heartSprites;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHeartUI()
    {
        currentHp = HealthManager.instance.currentHealth;

        if (heartSprites == null || heartSprites.Length == 0) return;

        for (int i = 0; i < heartSprites.Length; i++)
        {
            if (heartSprites[i] != null)
            {
                heartSprites[i].SetActive(i < currentHp);
            }
        }
    }
}
