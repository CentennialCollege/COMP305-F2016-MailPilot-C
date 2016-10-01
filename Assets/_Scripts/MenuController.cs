using UnityEngine;
using System.Collections;

// reference to UI elements
using UnityEngine.UI;

// reference to control Scenes
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public Button StartButton;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// PUBLIC METHODS +++++++++++++++++++++++++++++
	public void StartButton_Click() {
		SceneManager.LoadScene ("Game");
	}
}
