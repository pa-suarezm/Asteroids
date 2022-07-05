using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject prefabBasicAsteroid;

    private void Update()
    {
        if (GameStateManager.playingGame && !GameStateManager.paused && (Random.value < 1f / (60f)))
        {
            Instantiate(prefabBasicAsteroid, new Vector3(Random.Range(-4f, 4f), 10, 0), gameObject.transform.rotation, gameObject.transform);
        }
    }
}
