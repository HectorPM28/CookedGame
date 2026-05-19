using UnityEngine;

public class SaltShakerController : MonoBehaviour
{
    [SerializeField] private GameObject salt;
    private int numOfSalt = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numOfSalt; i++)
        {
            Instantiate(salt);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
