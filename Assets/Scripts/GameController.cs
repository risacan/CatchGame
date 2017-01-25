using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Camera cam;
	public Renderer rend;
	public GameObject ball;
	public float timeLeft;
	public Text timerText;
	private float maxWidth;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		rend = GetComponent<Renderer>();
//		float ballWidth = ball.rend.bounds.extents.x;
		float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		StartCoroutine (Spawn ());
	}
	
	void FixedUpdate () {
		timeLeft -= Time.deltaTime;
		timerText.text = "Time Left: \n" + Mathf.RoundToInt (timeLeft);
	}

	// Update is called once per frame
	IEnumerator Spawn () {
		yield return new WaitForSeconds (2.0f);
		while (timeLeft > 0) {
			Vector3 spawnPosition = new Vector3 (
				Random.Range (-maxWidth, maxWidth), // maxWidthの間でランダム
				transform.position.y,
				0.0f
			);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
		}
	}
}
