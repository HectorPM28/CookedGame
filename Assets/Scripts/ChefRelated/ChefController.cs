using UnityEngine;
using System.Collections;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;

public class ChefController : MonoBehaviour
{
    [SerializeField] private GameObject panPrefab;
    [SerializeField] private GameObject saltPrefab;

    private Animator animator;
    private Rigidbody2D rb;
    private GameObject weapon;

    [SerializeField]
    private float force, speed, horizontalMovement;

    private float treshold = 0.1f;
    private bool canJump = false, deadState = false, invincibleState = false;

    private Vector3 weaponOffset = new Vector3(2f, 20f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deadState) return;

        CheckHealth();

        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetMouseButtonDown(0))
        {
            ExecutePanAttack();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ExecuteSaltAttack();
        }
        if ((Input.GetKeyDown("w") || Input.GetKeyDown("up")) && canJump)
        {
            animator.SetBool("isJumping", true);
            rb.AddForce(transform.up * force, ForceMode2D.Impulse);
        }

        animator.SetBool("isRunning", Mathf.Abs(horizontalMovement) > treshold);
        if (horizontalMovement > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); //Mirar a derecha
        }
        else if (horizontalMovement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); //Mirar a izquierda
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * speed, rb.linearVelocity.y);
    }
    private void CheckHealth()
    {
        if (HealthManager.instance.currentHealth < 1 && !deadState)
        {
            StartCoroutine(DieSequence());
        }
    }
    private IEnumerator DieSequence()
    {
        deadState = true;

        animator.SetBool("isDead", true);
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = true;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("GameOver");
    }
    private IEnumerator InvincibleFrames()
    {
        invincibleState = true;

        yield return new WaitForSeconds(2f);

        invincibleState = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!invincibleState)
            {
                HealthManager.instance.TakeDamage();
                StartCoroutine(InvincibleFrames());
            }
        }else if (collision.gameObject.CompareTag("WinnerObject"))
        {
            SceneManager.LoadScene("Victory");

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!invincibleState)
            {
                HealthManager.instance.TakeDamage();
                StartCoroutine(InvincibleFrames());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       if (collision.gameObject.CompareTag("Trap"))
        {
            if (!invincibleState)
            {
                HealthManager.instance.TakeDamage();
                StartCoroutine(InvincibleFrames());
            }
        }
    }
    private void ExecutePanAttack()
    {
        if (weapon != null)
        {
            return;
        }

        Transform SpawnPanPointTransform = transform.Find("SpawnWeaponPoint");

        float angle = (transform.localScale.x < 0) ? 180f : 0f;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);

        weapon  = Instantiate(panPrefab, SpawnPanPointTransform.position + weaponOffset, rotation);
        Destroy(weapon, 0.5f);
    }
    private void ExecuteSaltAttack()
    {
        if (weapon != null)
        {
            return;
        }

        Transform SpawnPanPointTransform = transform.Find("SpawnWeaponPoint");
        
        float angle = (transform.localScale.x < 0) ? 180f : 0f;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);

        weapon = Instantiate(saltPrefab, SpawnPanPointTransform.position, rotation);
        Destroy(weapon, 0.5f);
    }
    public void SetCanJump(bool value)
    {
        canJump = value;
    }
}