using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
	private ParticleSystem exp;

	void Start() {
		exp = GetComponent<ParticleSystem>();
	}

	public void explode(Vector3 explosionPoint) {
		exp.transform.position = explosionPoint;
		exp.Play();
	}

}
