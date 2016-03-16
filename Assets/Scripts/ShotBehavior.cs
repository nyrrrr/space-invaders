using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{

    float fSpeed = 10f;
    Rigidbody2D rigidBody;

    // Use this for initialization
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rigidBody.velocity = Vector2.up * fSpeed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player") Destroy(gameObject);
    }
}
