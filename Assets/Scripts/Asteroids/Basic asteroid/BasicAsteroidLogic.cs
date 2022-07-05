using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAsteroidLogic : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody2D rgb;
    private SpriteRenderer sprite;
    private CircleCollider2D circleCollider;
    private ParticleSystem particles;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rgb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        particles = GetComponent<ParticleSystem>();

        float random = Random.Range(-1f, 1f);
        if (random < 0.3f && random > -0.3f)
        {
            random = Mathf.Sign(random);
        }
        gameObject.transform.localScale = new Vector3(Mathf.Sign(random), 1f, 1f);
        rgb.angularVelocity = random * 100;
        rgb.velocity = new Vector2(0, -5 * (Mathf.Abs(random)));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameStateManager.playingGame)
        {
            if (GameStateManager.soundFX)
            {
                audioSource.Play();
            }
            rgb.angularVelocity = 0;
            particles.Play();
            sprite.enabled = false;
            circleCollider.enabled = false;
            Destroy(gameObject, 1);
            GameStateManager.instance.AddPoints(250);
        }
    }
}
