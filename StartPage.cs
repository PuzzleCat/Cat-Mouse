using UnityEngine;
using System.Collections;

public class StartPage : MonoBehaviour {

	private int stage;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		stage = PlayerPrefs.GetInt ("Stage");
		StartCoroutine (delay ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator delay(){
		yield return new WaitForSeconds (3);
		Application.LoadLevel ("Start");
	}
}
