using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpinner : MonoBehaviour {
	public float spinSpeed;
	public float orbitSpeed;
	private GameObject sunObject;
	private GameObject meteor;

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
		Vector3 meteorPosition = meteor.transform.position;
		Vector3 earthPosition = transform.position;

		if (Vector3.Distance(meteorPosition, earthPosition) <= GetComponent<Renderer>().bounds.size.x) {
			meteor.SetActive (false);
		}
	}
}