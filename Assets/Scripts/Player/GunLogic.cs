using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    public GameObject prefabBlasterShot;

    private bool alreadyShot = false;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float shot = Input.GetAxis("Fire");

        if (shot == 1 && !alreadyShot)
        {
            alreadyShot = true;
            Instantiate(prefabBlasterShot, gameObject.transform);
            if (GameStateManager.soundFX)
            {
                audioSource.Play();
            }
        }
        else if (shot == 0)
        {
            alreadyShot = false;
        }
    }
}
