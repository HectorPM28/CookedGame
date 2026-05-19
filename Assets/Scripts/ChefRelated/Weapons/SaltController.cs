using UnityEngine;

public class SaltController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject spawnPoint;

    private float minXForce = 0.7f, maxXForce = 1.5f, minYForce = 1f, maxYForce = 1.5f, randomX, randomY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spawnPoint = GameObject.Find("SpawnWeaponPoint");
        float direccionX = Mathf.Sign(spawnPoint.transform.lossyScale.x);
        rb.position = spawnPoint.transform.position;

        randomX = Random.Range(minXForce, maxXForce);
        randomY = Random.Range(minYForce, maxYForce);
        Vector2 force = new Vector2 (randomX * direccionX, randomY);
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
