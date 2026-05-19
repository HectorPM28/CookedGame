using System.Collections;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireTrapController : MonoBehaviour
{
    private Animator animator;
    private new Collider2D collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        StartCoroutine(StartFire());
    }

    private IEnumerator StartFire()
    {
        animator.SetBool("startFire", true);
        collider.enabled = true;
        yield return new WaitForSeconds(2f);

        animator.SetBool("startFire", false);
        collider.enabled = false;

        yield return new WaitForSeconds(4f);

        StartCoroutine(StartFire());
    }
}
