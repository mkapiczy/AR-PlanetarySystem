using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour {

	private GameObject earth;
	private GameObject moon;
	private Vector3 initialPosition;
	private bool towards = true;
	private float speed = 0.05f;
	// Use this for initialization
	void Start () {
		earth = GameObject.Find("Earth");
		moon = GameObject.Find("Moon");
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (towards) {
			transform.position = Vector3.MoveTowards (transform.position, earth.transform.position, speed);
			if(Vector3.Distance (transform.position, earth.transform.position) <= 0.5){
			towards = false;
			}
		} else {
			transform.position = Vector3.MoveTowards (transform.position, initialPosition, speed);
			if (Vector3.Distance (transform.position, initialPosition) <= 0.5) {
				towards = true;
			}
		}
	}
}
