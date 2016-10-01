using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	private AudioSource[] _sounds;
	private AudioSource _thunderSound;
	private AudioSource _yaySound;

	// PUBLIC INSTANCE VARIABLES (For Testing) ++++++++++++++++++++++++++++++++++
	public GameController gameController;


	// Use this for initialization
	void Start () {
		this._transform = this.GetComponent<Transform> ();
		this._sounds = this.GetComponents<AudioSource> ();
		this._thunderSound = this._sounds [1];
		this._yaySound = this._sounds [2];
	}
	
	// Update is called once per frame
	void Update () {
		this._move ();
	}

	/**
	 * this method moves the game object across the x-axis following the mouse movement
	 */
	private void _move() {
		this._transform.position = new Vector2 (Mathf.Clamp(Input.mousePosition.x - 320f,-290f, 290f), -200f);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.CompareTag ("Island")) {
			this.gameController.ScoreValue += 100;
			this._yaySound.Play ();
		}

		if (other.gameObject.CompareTag ("Cloud")) {
			this.gameController.LivesValue -= 1;
			this._thunderSound.Play ();
		}

	}
		
}
