using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public float spawnForce = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();

            Vector3 randomDirection = new Vector3(
                        Random.Range(-1f, 1f),
                        Random.Range(0.5f, 1f),
                        Random.Range(-1f, 1f)
                    ).normalized;

            rb.AddForce(randomDirection * spawnForce, ForceMode.Impulse);
        }

    }

}
