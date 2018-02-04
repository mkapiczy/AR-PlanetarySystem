using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpinner : MonoBehaviour {
	public float spinSpeed;
	public float orbitSpeed;
	private GameObject sunObject;
	private GameObject meteor;
	public GameObject explosion;
	private Vector3 meteorInitialPoint;

	// Use this for initialization
	void Start () {
		sunObject = GameObject.Find("Sun");
		meteor = GameObject.Find ("Meteor");
		explosion = GameObject.Find ("Explosion");
		meteorInitialPoint = meteor.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
		transform.RotateAround (sunObject.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
		if (isCollidingWithMeteor()) {
			Instantiate (explosion, getIntersectionPoint(), Quaternion.identity);
		}
	}

	bool isCollidingWithMeteor() {
		Vector3 earthPosition = transform.position;
		Vector3 meteorPosition = meteor.transform.position;

		float distance = Vector3.Distance(meteorPosition, earthPosition);

		float earthRadius = transform.localScale.x / 2.0f;
		float meteorRadius = meteor.transform.localScale.x / 2.0f;


		return distance <= meteorRadius + earthRadius;
	}

	Vector3 getIntersectionPoint(){
		Vector3 positionDifference = transform.position - meteor.transform.position;

		float earthRadius = transform.localScale.x / 2.0f;

		return transform.position + (positionDifference * earthRadius/positionDifference.magnitude);
	}
}