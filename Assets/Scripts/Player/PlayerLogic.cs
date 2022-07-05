using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public AudioClip getsHit;
    public AudioClip dies;

    private AudioSource audioSource;

    private ParticleSystem playerParticleSystem;

    private Rigidbody2D rgb;
    public float speedMult = 5f;
    private float moveThreshold = 0.15f;

    protected int hp = 3;

    void Start()
    {
        hp = 3;
        playerParticleSystem = GetComponent<ParticleSystem>();
        var main = playerParticleSystem.main;
        main.stopAction = ParticleSystemStopAction.Callback;
        audioSource = GetComponent<AudioSource>();
        rgb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (GameStateManager.playingGame && !GameStateManager.paused)
        {
            float v = 0f;

            //Keyboard input
            float keyboardInput = Input.GetAxis("Horizontal");
            if (keyboardInput != 0)
            {
                v = Mathf.Sign(keyboardInput) * speedMult;
            }

            //Tilt input
            float moveX = Input.acceleration.x;
            if (Mathf.Abs(moveX) >= moveThreshold)
            {
                v = Mathf.Sign(moveX) * speedMult;
            }

            //New speed
            rgb.velocity = new Vector2(v, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            if (GameStateManager.soundFX)
            {
                audioSource.PlayOneShot(getsHit);
            }
            hp--;
            HealthUI.OnHealthLoss(hp);
            if (hp == 0)
            {
                playerParticleSystem.Play();
                rgb.angularVelocity = 500;
                GetComponent<SpriteRenderer>().enabled = false;
                GameStateManager.instance.GameOver();
            }
        }
    }

    private void OnParticleSystemStopped()
    {
        gameObject.SetActive(false);
    }
}
