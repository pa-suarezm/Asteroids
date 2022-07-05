using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastLogic : MonoBehaviour
{
    private Rigidbody2D rgb;

    public float speed = 100;
    public float lifetime = 1;

    // Start is called before the first frame update
    void Start()
    {
        rgb = gameObject.GetComponent<Rigidbody2D>();
        rgb.velocity = new Vector2(0, speed);
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
