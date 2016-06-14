using UnityEngine;
using System.Collections;

public class playerScript_ex00 : MonoBehaviour {

	public bool focus = false;
	public float jump  = 5.0f;
	public float speed = 2.0f;

	private bool canJump = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (focus) {
			float vertical = GetComponent<Rigidbody2D>().velocity.y;
			if (canJump && (Input.GetKeyDown ("space") || Input.GetKeyDown ("up"))) {
				vertical = jump;
				canJump = false;
			}
			GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, vertical);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.enabled) {
			if (coll.contacts.Length > 0) {
				ContactPoint2D contact = coll.contacts [0];
				if (Vector2.Dot (contact.normal, Vector2.up) > 0.5) {
					canJump = true;
				}
			}
		}
	}
}
