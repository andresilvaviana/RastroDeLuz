using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 direction;

    void Start()
    {
        ChooseDirection();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Se bater em algo, muda direção
        ChooseDirection();
    }
    void ChooseDirection()
    {
        int rand = Random.Range(0, 4);

        if (rand == 0) direction = Vector2.up;
        if (rand == 1) direction = Vector2.down;
        if (rand == 2) direction = Vector2.left;
        if (rand == 3) direction = Vector2.right;
    }
}
