using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public Transform gun;

    Rigidbody2D rigidBody;

    public GameObject projectilePrefab;
    GameObject projectile = null;

    float fHorizontal, fSpeed = 10f, fShoot;

    // Use this for initialization
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        fShoot = Input.GetAxisRaw("Jump");
        if (fShoot > 0 && projectile == null)
        {
            projectile = (GameObject)Instantiate(projectilePrefab, gun.position, Quaternion.identity);
        }
    }

    // Update is called once per fixed frame rate
    void FixedUpdate()
    {
        fHorizontal = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = Vector2.right * fHorizontal * fSpeed;
    }
}
