using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpinner : MonoBehaviour {
	public float spinSpeed= 60f;
	public float orbitSpeed = 0.01f;
	private GameObject sunObject;
	public float a = 9f;
	public float b = 6f;
	private float angle;

	// Use this for initialization
	void Start () {
		sunObject = GameObject.Find("Sun");
		angle = Mathf.Acos (transform.position.x / (a * 180));
	}
	
	// Update is called once per frame
	void Update ()
	{
		angle = angle + orbitSpeed;

		Vector3 newPosition = new Vector3 (a*Mathf.Cos(angle),transform.position.y,b*Mathf.Sin(angle));

		//transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
		Quaternion originalRot = transform.rotation;    
		transform.rotation = originalRot * Quaternion.AngleAxis(spinSpeed * Time.deltaTime, Vector3.up);
		transform.position = newPosition;
	}

}