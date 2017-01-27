using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public int ballValue;
	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore();
	}
	
	void UpdateScore () {
		if (score < 0) {
			score = 0;
		}
		scoreText.text = "Score: \n" + score;
	}

	void OnTriggerEnter2D (Collider2D coll) {
		switch (coll.gameObject.tag) {
			case "bomb":
			  score -= ballValue;
			  break;
			case "ball":
			  score += ballValue;
			  break;
		}
		UpdateScore();
	}
}
