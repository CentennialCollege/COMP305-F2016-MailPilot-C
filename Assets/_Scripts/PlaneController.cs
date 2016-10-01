using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES
	private Transform _transform;

	// PUBLIC INSTANCE VARIABLES (For Testing) ++++++++++++++++++++++++++++++++++
	public GameController gameController;


	// Use this for initialization
	void Start () {
		this._transform = this.GetComponent<Transform> ();
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
			Debug.Log ("Island Hit!");
			this.gameController.ScoreValue += 100;
		}

		if (other.gameObject.CompareTag ("Cloud")) {
			Debug.Log ("Cloud Hit!");
			this.gameController.LivesValue -= 1;
		}

	}
		
}
