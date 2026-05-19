using UnityEngine;

public class GroundChecker: MonoBehaviour
{
    private ChefController playerScript;

    void Start()
    {
        playerScript = GetComponentInParent<ChefController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            playerScript.SetCanJump(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            playerScript.SetCanJump(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            playerScript.SetCanJump(false);
        }
    }
}
