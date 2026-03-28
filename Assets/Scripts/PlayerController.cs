using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        CreateTrail();
    }

    void CreateTrail()
    {
        trailTimer -= Time.deltaTime;

        if (trailTimer <= 0)
        {
            Instantiate(trailPrefab, transform.position, Quaternion.identity);
            trailTimer = 0.1f;
        }
    }
}
