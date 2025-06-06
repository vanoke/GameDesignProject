using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticEffect : MonoBehaviour
{
    public GameObject player;
    public float attractionSpeed = 3f;
    public float attractionRadius = 5f;

    void Update()
    {
        Collider[] objectsInRange = Physics.OverlapSphere(player.transform.position, attractionRadius);
        foreach (Collider col in objectsInRange)
        {
            if (col.gameObject != player && col.gameObject.tag != "Ground")
            {
                Vector3 direction = player.transform.position - col.transform.position;
                col.transform.position += direction.normalized * attractionSpeed * Time.deltaTime;
            }
        }
    }
}
