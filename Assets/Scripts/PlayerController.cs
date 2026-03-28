using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 move;

    public GameObject trailPrefab;
    private float trailTimer = 0.1f;

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        transform.Translate(move.normalized * speed * Time.deltaTime);

        if (move != Vector2.zero)
        {
            CreateTrail();
        }
    }

    void CreateTrail()
    {
        trailTimer -= Time.deltaTime;

        if (trailTimer <= 0)
        {
            Vector3 offset = new Vector3(-move.x, -move.y, 0) * 0.5f;
            Instantiate(trailPrefab, transform.position + offset, Quaternion.identity);
            trailTimer = 0.1f;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trail"))
        {
            Debug.Log("Perdeu!");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Perdeu para inimigo!");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

}
