using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCrasher : MonoBehaviour
{
    public GameObject cubePiecePrefab;
    public float explodeForce = 500f;

    private void OnCollisionEnter(Collision collision)

    { 
        if (collision.gameObject.CompareTag("Ground"))
        { ExplodeCube(); }
    
    }


    private void ExplodeCube()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int z = 0; z < 4; z++)
                {
                    Vector3 piecePosition = transform.position + new Vector3(x, y, z) * 0.5f;
                    GameObject piece = Instantiate(cubePiecePrefab, piecePosition, Quaternion.identity);
                    Rigidbody pieceRigidbody = piece.GetComponent<Rigidbody>();
                    pieceRigidbody.AddExplosionForce(explodeForce, transform.position, 5f);

                }

            }

        }
        Destroy(gameObject);
    }

}
