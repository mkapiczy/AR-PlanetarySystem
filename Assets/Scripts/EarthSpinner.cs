using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpinner : MonoBehaviour {
	public float spinSpeed;
	public float orbitSpeed;
	private GameObject sunObject;

	// Use this for initialization
	void Start () {
		sunObject = GameObject.Find("Sun");
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

		transform.RotateAround (sunObject.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
	}
}