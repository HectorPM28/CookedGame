using Unity.VisualScripting;
using UnityEngine;

public class Teleporter: MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D teleportEndDestination;
    [SerializeField]
    private Rigidbody2D teleportStartDestination;

    private Rigidbody2D rb;

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == teleportStartDestination.gameObject)
        {
            rb.position = teleportEndDestination.position;
        }
    }
}
