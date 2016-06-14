using UnityEngine;
using System.Collections;

public class handlePlayer_ex01 : MonoBehaviour {

	public cameraScript_ex01 mainCamera;
	private playerScript_ex01[] players;

	// Use this for initialization
	void Start () {
		players = GameObject.FindObjectsOfType<playerScript_ex01>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("r") || Input.GetKeyDown ("backspace")) {
			Application.LoadLevel(Application.loadedLevel);
			return;
		}
		int i;
		for (i = 0; i < players.Length; ++i) {
			if (Input.GetKeyDown ((i+1).ToString())) {
				for (int j = 0; j < players.Length; ++j) {
					players[j].focus = false;
//					players[j].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
				}
				players[i].focus = true;
//				players[i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				mainCamera.mc = players[i].gameObject;
				break;
			}
		}
		for (i = 0; i < players.Length; ++i) {
			if (players [i].win == false)
				return;
		}
		Debug.Log("You win!");
		Application.LoadLevel(Application.loadedLevel);
	}
}
