using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    Transform go;
    Rigidbody2D rigidBody;

    Enemy[] enemies;

    float fSpeed = 5f;
    bool isMovingLeft = true;

    // Use this for initialization
    void Awake()
    {
        go = this.transform;
        rigidBody = GetComponent<Rigidbody2D>();
        enemies = FindObjectsOfType(typeof(Enemy)) as Enemy[];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = (isMovingLeft ? Vector2.left : Vector2.right) * fSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // only for debug now
        if (other.gameObject.tag != "Enemy")
        {
            var tmp = 0f;
            foreach (Enemy enemy in enemies)
            {
                tmp = (tmp == 0f ? tmp = enemy.transform.position.x : tmp - enemy.transform.position.x);
                if (enemy.isMovingLeft) enemy.isMovingLeft = false;
                else enemy.isMovingLeft = true;
            }
            Debug.Log(tmp);
        }
    }
}