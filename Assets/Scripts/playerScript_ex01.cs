using UnityEngine;
using System.Collections;

public class playerScript_ex01 : MonoBehaviour {

	public int id = 0;
	public bool win = false;
	
	public bool focus = false;
	public float jump  = 5.0f;
	public float speed = 2.0f;

	private bool canJump = false;

	// Use this for initialization
	void Start () {
//		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update () {
		float vertical = GetComponent<Rigidbody2D> ().velocity.y;
		if (focus) {
			if (canJump && (Input.GetKeyDown ("space") || Input.GetKeyDown ("up"))) {
				vertical = jump;
				canJump = false;
			}
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, vertical);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, vertical);
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
	
	void OnTriggerEnter2D(Collider2D coll) {
		goalScript_ex01 goal = coll.gameObject.GetComponent<goalScript_ex01>();
		if (goal && goal.id == this.id)
			win = true;
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		goalScript_ex01 goal = coll.gameObject.GetComponent<goalScript_ex01>();
		if (goal && goal.id == this.id)
			win = false;
	}
}
