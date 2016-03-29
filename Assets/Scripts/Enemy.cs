using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidBody;

    static List<Enemy> enemies;

    float fSpeed = 2f;
    bool isMovingLeft = true;
    bool tmpSave;

    // Use this for initialization
    void Awake()
    {
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
            enemies.Remove(this);
            Destroy(other.gameObject);
            Destroy(gameObject);
            // TODO handle score and further enemy behaviour
        }
        else if (other.gameObject.tag != "Enemy")
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.isMovingLeft) enemy.isMovingLeft = false;
                else enemy.isMovingLeft = true;
                if (tmpSave == enemy.isMovingLeft) enemy.isMovingLeft = !tmpSave;
            }
        }
    }
}