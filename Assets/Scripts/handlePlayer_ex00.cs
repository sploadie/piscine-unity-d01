using UnityEngine;
using System.Collections;

public class handlePlayer_ex00 : MonoBehaviour {

	public cameraScript_ex00 mainCamera;
	private playerScript_ex00[] players;

	// Use this for initialization
	void Start () {
		players = GameObject.FindObjectsOfType<playerScript_ex00>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("r") || Input.GetKeyDown ("backspace")) {
			Application.LoadLevel(Application.loadedLevel);
			return;
		}
		for (int i = 0; i < players.Length; ++i) {
			if (Input.GetKeyDown ((i+1).ToString())) {
				for (int j = 0; j < players.Length; ++j) {
					players[j].focus = false;
				}
				players[i].focus = true;
				mainCamera.mc = players[i].gameObject;
				break;
			}
		}
	}
}
