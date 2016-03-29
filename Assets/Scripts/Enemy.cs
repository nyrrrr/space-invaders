using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidBody;

    //class vars
    static List<Enemy> enemies;

    static float fSpeed = 2f, fDownSpeed = 2f;
    static bool isMovingDown = false;

    bool isMovingLeft = true;
    bool tmpSave; // monkey fix var

    // Use this for initialization
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        enemies = new List<Enemy>(FindObjectsOfType(typeof(Enemy)) as Enemy[]);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isMovingDown) rigidBody.velocity = (isMovingLeft ? Vector2.left : Vector2.right) * fSpeed;
        else rigidBody.velocity = Vector2.down * fDownSpeed;
    }
    void Update()
    {
        tmpSave = isMovingLeft;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerShot")
        {
            fSpeed += 0.1f;
            enemies.Remove(this);
            Destroy(other.gameObject);
            Destroy(gameObject);
            // TODO handle score and further enemy behaviour
        }
        else if (other.gameObject.tag != "Enemy")
        {
            isMovingDown = true;
            StartCoroutine(MoveDownTrigger());
            foreach (Enemy enemy in enemies)
            {
                if (enemy.isMovingLeft) enemy.isMovingLeft = false;
                else enemy.isMovingLeft = true;
                if (tmpSave == enemy.isMovingLeft) enemy.isMovingLeft = !tmpSave;
            }
        }
    }

    private IEnumerator MoveDownTrigger()
    {
        yield return new WaitForSeconds(0.1f);
        isMovingDown = false;
    }
}