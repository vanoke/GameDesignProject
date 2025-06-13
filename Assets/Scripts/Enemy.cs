using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject cubePiecePrefab;
    public float explodeForce = 300f;
    public AudioClip destructionSound; // 1. Добавляем переменную для звука /// NEW
    [SerializeField] TextMeshProUGUI textScore;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(destructionSound, transform.position); // 2. Воспроизводим звук /// NEW
            ExplodeCube();
            AddScore();
        }
    }
    void Start()
    { 
        textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();
    }

    private void AddScore()
    {
        Progress.Instance.PlayerInfo.Score += 10;
        textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();

        if (Progress.Instance.PlayerInfo.Score == 100)
        {
            Progress.Instance.PlayerInfo.Score = 0;
            SceneManager.LoadScene("MainLevel");
        }
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