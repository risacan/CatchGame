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
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject startButton;
	private float maxWidth;
	private bool playing;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		playing = false;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		rend = GetComponent<Renderer>();
		float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		UpdateText();
	}
	
	void FixedUpdate () {
		if (playing) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			UpdateText();
		}
	}

	public void StartGame () {
		startButton.SetActive (false);
		StartCoroutine (Spawn ());
	}

	// Update is called once per frame
	IEnumerator Spawn () {
		playing = true;
		while (timeLeft > 0) {
			Vector3 spawnPosition = new Vector3 (
				Random.Range (-maxWidth, maxWidth), // maxWidthの間でランダム
				transform.position.y,
				0.0f
			);

			Vector3 gravitySample = new Vector3 (
				0.0f, 
				-200.0f,
				0.0f
			);
			Quaternion spawnRotation = Quaternion.identity;
			GameObject b =
			  GameObject.Instantiate (ball, spawnPosition, spawnRotation) as GameObject;
			b.transform.GetComponent<Rigidbody2D>().AddForce(gravitySample);
			yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
		}
		yield return new WaitForSeconds (2.0f);
		gameOverText.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		restartButton.SetActive (true);
	}
	
	void UpdateText () {
		timerText.text = "Time Left:\n" + Mathf.RoundToInt (timeLeft);
	}
}
