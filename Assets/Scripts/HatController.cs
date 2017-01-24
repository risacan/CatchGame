using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour {
	public Camera cam;
	public Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	    if (cam == null)	{
		    cam = Camera.main;
	  }
	}
	
	// Update is called once per physics timestep
	void FixedUpdate () {
		Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (rawPosition.x, -2.76f, 0.0f);
		rb2D.MovePosition(targetPosition);
	}
}
