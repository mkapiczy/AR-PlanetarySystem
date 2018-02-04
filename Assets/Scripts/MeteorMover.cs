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
			if(isCollidingWithEarth()){
				towards = false;
			}
		} else {
			transform.position = Vector3.MoveTowards (transform.position, initialPosition, speed);
			if (Vector3.Distance (transform.position, initialPosition) <= 0.1) {
				towards = true;
			}
		}
	}

	bool isCollidingWithEarth() {
		Vector3 earthPosition = earth.transform.position;
		Vector3 meteorPosition = transform.position;

		float distance = Vector3.Distance(meteorPosition, earthPosition);

		float earthRadius = earth.transform.localScale.x / 2.0f;
		float meteorRadius = transform.localScale.x / 2.0f;

		return distance <= meteorRadius + earthRadius - 0.1f;
	}

}
