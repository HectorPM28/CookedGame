using System.Collections;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController: MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public float speed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (speed > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); //Mirar a derecha
        }
        else if (speed < 0)
        {
            transform.localScale = new Vector3(1, 1, 1); //Mirar a izquierda
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            StartCoroutine(DieSequence());
        }else if (collision.gameObject.CompareTag("EnemyWalkInverter"))
        {
            speed *= -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            speed = speed * -1;
        }
    }
    private IEnumerator DieSequence()
    {
        animator.SetBool("isDead", true);
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
