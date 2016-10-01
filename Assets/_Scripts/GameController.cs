using UnityEngine;
using System.Collections;

// needed for UI elements
using UnityEngine.UI;

// needed for switching scenes
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES ++++++++++++++++++++++++++++++++++++++++
	private int _scoreValue = 0;
	private int _livesValue = 5;
	private AudioSource _gameOverSound;

	// PUBLIC INSTANCE VARIABLES (FOR TESTING) +++++++++++++++++++++++++++
	public int cloudNumber = 3;
	public GameObject cloud;
	public Text LivesLabel;
	public Text ScoreLabel;
	public Text GameOverLabel;
	public Text FinalScoreLabel;
	public Button RestartButton;
	public GameObject plane;
	public GameObject island;


	// PUBLIC PROPERTIES +++++++++++++++++++++++++++++++++++++++++++++++++
	public int ScoreValue {
		get {
			return this._scoreValue;
		}

		set {
			this._scoreValue = value;
			this.ScoreLabel.text = "Score: " + this._scoreValue;
		}
	}

	public int LivesValue {
		get {
			return this._livesValue;
		}

		set {
			this._livesValue = value;
			if (this._livesValue <= 0) {
				// end the game
				this._endGame ();
			} else {
				this.LivesLabel.text = "Lives: " + this._livesValue;
			}
		}
	}

	// Use this for initialization
	void Start () {
		this._gameOverSound = this.GetComponent<AudioSource> ();
		this.GameOverLabel.gameObject.SetActive (false);
		this.FinalScoreLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (false);

		// repeat cloudCount times
		for (int cloudCount= 0; cloudCount < this.cloudNumber; cloudCount++) {
			Instantiate (this.cloud);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void _endGame() {
		this.plane.SetActive (false);
		this.island.SetActive (false);
		this.LivesLabel.gameObject.SetActive (false);
		this.ScoreLabel.gameObject.SetActive (false);
		this._gameOverSound.Play ();
		this.GameOverLabel.gameObject.SetActive (true);
		this.FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
		this.FinalScoreLabel.gameObject.SetActive (true);
		this.RestartButton.gameObject.SetActive (true);
	}

	// PUBLIC METHODS

	public void RestartButton_Click() {
		SceneManager.LoadScene ("Game");
	}
}
