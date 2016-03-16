using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Transform go;

    Rigidbody2D rigidBody;

    float fHorizontal, fSpeed = 10f;

	// Use this for initialization
	void Awake () {
        go = this.transform;
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        fHorizontal = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = Vector2.right * fHorizontal * fSpeed;
	}
}
