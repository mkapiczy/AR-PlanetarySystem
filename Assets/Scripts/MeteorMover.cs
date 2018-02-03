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
			Vector3 ip;
			if(Intersect(out ip)){
				towards = false;
			}
		} else {
			transform.position = Vector3.MoveTowards (transform.position, initialPosition, speed);
			if (Vector3.Distance (transform.position, initialPosition) <= 0.5) {
				towards = true;
			}
		}
	}

	bool isCollidingWithEarth() {
		Vector3 meteorPosition = transform.position;
		Vector3 earthPosition = earth.transform.position;
		float earthRadius = GetComponent<Renderer> ().bounds.extents.magnitude * transform.localScale.magnitude;
		float moonRadius = earth.GetComponent<Renderer> ().bounds.extents.magnitude * earth.transform.localScale.magnitude;
		return Vector3.Distance (meteorPosition, earthPosition) <= (earthRadius + moonRadius);
	}

	bool Intersect(out Vector3 ip, float threshold=0.1f){
		// vector from sphere 1 -> sphere 2
		Vector3 ab = transform.position - earth.transform.position;

		// Calculate radius from Unity built-in sphere.
		// Unity spheres are unit spheres (diameter = 1)
		// So diameter = scale, thus radius = scale / 2.0f.
		// **Presumes uniform scaling.
		float r1 = transform.localScale.x / 2.0f;
		float r2 = earth.transform.localScale.x / 2.0f;

		// When spheres are too close or too far apart, ignore intersection.
		float diff = Mathf.Abs(r2 + r1 - ab.magnitude);
		if( diff >= threshold) {
			ip = Vector3.zero;
			return false;
		}
		// Intersection is the distance along the vector between
		// the 2 spheres as a function of the sphere's radius.
		ip = transform.position + ab * r1/ab.magnitude;
		return true;
	}
}
