using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform gun;
    Rigidbody2D rigidBody;

    public GameObject projectilePrefab;
    GameObject projectile = null;

    //class vars
    static List<Enemy> enemies;

    static float fSpeed = 2f, fDownSpeed = 2f;
    static bool isMovingDown = false;

    int iAttackIndicator = 360;

    bool isMovingLeft = true;
    bool isAttacking = false;
    bool tmpSave; // monkey fix var

    // Use this for initialization
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        enemies = new List<Enemy>(FindObjectsOfType(typeof(Enemy)) as Enemy[]);
        projectilePrefab.GetComponent<ShotBehavior>().SetIsShotByPlayer(false);
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

        isAttacking = (Random.Range(1, iAttackIndicator + 1) == iAttackIndicator ? true : false);
        if (isAttacking && projectile == null)
        {
            projectile = (GameObject)Instantiate(projectilePrefab, gun.position, Quaternion.identity);
            projectile.GetComponent<ShotBehavior>().SetIsShotByPlayer(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerShot" && other.gameObject.GetComponent<ShotBehavior>().GetIsShotByPlayer())
        {
            fSpeed += 0.1f;
            enemies.Remove(this);
            Destroy(other.gameObject);
            Destroy(gameObject);
            // TODO handle score and further enemy behaviour
        }
        else if (other.gameObject.tag == "Border")
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