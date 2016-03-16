using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Transform go;

    Rigidbody2D rigidBody;

    float fHorizontal, fSpeed = 0.2f;

	// Use this for initialization
	void Awake () {
        go = this.transform;
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        fHorizontal = Input.GetAxisRaw("Horizontal");
        go.Translate(fHorizontal * fSpeed, 0, go.position.z);
	}
}
