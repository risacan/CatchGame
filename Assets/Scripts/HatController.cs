using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour {
	public Camera cam;
	public Rigidbody2D rb2D;
	public Vector3 position;
	public Renderer rend;
	private float maxWidth;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		position = transform.position;
		rb2D = GetComponent<Rigidbody2D>();
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		rend = GetComponent<Renderer>();
		float hatWidth = rend.bounds.extents.x;
		maxWidth = targetWidth.x - hatWidth/2;
	}
	
	// Update is called once per physics timestep
	void FixedUpdate () {
		Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (rawPosition.x, position.y, 0.0f);
		float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
		targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
		rb2D.MovePosition(targetPosition);
	}
}
