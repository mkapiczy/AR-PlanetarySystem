using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotator : MonoBehaviour {

	public float spinSpeed = 20f;
	public float orbitSpeed = 0.002f;
	public float a = 3f;
	public float b = 2f;
	private float angle;
	private GameObject earthObject;


	// Use this for initialization
	void Start () {
		earthObject = GameObject.Find("Earth");
		angle = Mathf.Acos((transform.position.x - earthObject.transform.position.x) / (a * 180));
	}

	// Update is called once per frame
	void Update ()
	{
		angle = angle + orbitSpeed;
		Vector3 newPosition = new Vector3 (earthObject.transform.position.x + a*Mathf.Cos(angle),transform.position.y,earthObject.transform.position.z + b*Mathf.Sin(angle));
		//transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
		Quaternion originalRot = transform.rotation;    
		transform.rotation = originalRot * Quaternion.AngleAxis(spinSpeed * Time.deltaTime, Vector3.up);
		transform.position = newPosition;
	}
}
