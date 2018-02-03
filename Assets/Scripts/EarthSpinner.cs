using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpinner : MonoBehaviour {
	public float spinSpeed;
	public float orbitSpeed;
	private GameObject sunObject;
	private GameObject meteor;
	public Explode explosion;

	// Use this for initialization
	void Start () {
		sunObject = GameObject.Find("Sun");
		meteor = GameObject.Find ("Meteor");
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
		transform.RotateAround (sunObject.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
		Vector3 intersectionPoint;
		if (Intersect(out intersectionPoint)) {
			explosion.explode (intersectionPoint);
		}
	}

	bool isCollidingWithMeteor() {
		Vector3 earthPosition = transform.position;
		Vector3 meteorPosition = meteor.transform.position;
		float earthRadius = GetComponent<Renderer> ().bounds.extents.magnitude * transform.localScale.magnitude;
		float moonRadius = meteor.GetComponent<Renderer> ().bounds.extents.magnitude * meteor.transform.localScale.magnitude;
		return Vector3.Distance (meteorPosition, earthPosition) <= (earthRadius + moonRadius);
	}

	bool Intersect(out Vector3 ip, float threshold=0.1f){
		// vector from sphere 1 -> sphere 2
		Vector3 ab = transform.position - meteor.transform.position;

		// Calculate radius from Unity built-in sphere.
		// Unity spheres are unit spheres (diameter = 1)
		// So diameter = scale, thus radius = scale / 2.0f.
		// **Presumes uniform scaling.
		float r1 = transform.localScale.x / 2.0f;
		float r2 = meteor.transform.localScale.x / 2.0f;

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