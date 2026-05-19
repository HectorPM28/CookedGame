using UnityEngine;

public class ChefIntro_Controller : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    public float force, speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jumpad"))
        {
            animator.SetBool("isRunning", false);
            rb.AddForce(transform.up * force, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", true);
        }
    }
}
