using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Enemy : MonoBehaviour
{
    Transform go;
    Rigidbody2D rigidBody;

    static List<Enemy> enemies;

    float fSpeed = 5f;
    bool isMovingLeft = true;
    bool tmpSave;

    // Use this for initialization
    void Awake()
    {
        go = this.transform;
        rigidBody = GetComponent<Rigidbody2D>();
        enemies = new List<Enemy>(FindObjectsOfType(typeof(Enemy)) as Enemy[]);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = (isMovingLeft ? Vector2.left : Vector2.right) * fSpeed;
    }
    void Update() {
        tmpSave = isMovingLeft;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerShot")
        {
            Debug.Log("Hit by shot");
            enemies.Remove(this);
            Destroy(other.gameObject);
            Destroy(gameObject);
            // TODO handle score and further enemy behaviour
        }
        else if (other.gameObject.tag != "Enemy")
        {
            Debug.Log("Hit border");
            foreach (Enemy enemy in enemies)
            {
                if (enemy.isMovingLeft) enemy.isMovingLeft = false;
                else enemy.isMovingLeft = true;
                if (tmpSave == enemy.isMovingLeft) enemy.isMovingLeft = !tmpSave;
            }
        }
        Debug.Log(isMovingLeft);
    }
}