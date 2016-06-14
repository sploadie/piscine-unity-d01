using UnityEngine;
using System.Collections;

public class cameraScript_ex01 : MonoBehaviour {

	public GameObject mc = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (mc != null) {
			transform.position = new Vector3(mc.transform.position.x, mc.transform.position.y, -10);
		} else {
			transform.position = new Vector3(0,0,-10);
		}
	}
}
