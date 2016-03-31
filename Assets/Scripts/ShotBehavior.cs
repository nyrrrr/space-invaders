using UnityEngine;

public class ShotBehavior : MonoBehaviour
{

    float fSpeed = 8f;
    Rigidbody2D rigidBody;
    bool isShotByPlayer = true;

    // Use this for initialization
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = (isShotByPlayer ? Vector2.up : Vector2.down) * fSpeed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player" && isShotByPlayer) Destroy(gameObject);
        else if (col.gameObject.tag != "Enemy" && !isShotByPlayer) Destroy(gameObject);
    }

    public void SetIsShotByPlayer(bool b) {
        isShotByPlayer = b;
    }

    public bool GetIsShotByPlayer() {
        return isShotByPlayer;
    }
}
