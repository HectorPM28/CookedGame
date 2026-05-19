using System;
using UnityEngine;

public class ChickenCoin_script : MonoBehaviour
{
    [SerializeField]
    private AudioClip AudioClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chef"))
        {
            HudController hud = FindAnyObjectByType<HudController>();
            hud.GrabCoin();
            AudioManager.instance.PlayCoinSound(AudioClip);
            Destroy(gameObject);
        }
    }
}
