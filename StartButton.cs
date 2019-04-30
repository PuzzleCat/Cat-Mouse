using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour {

	public GameObject panel;
	public GameObject panel1;
	public GameObject barrel1;
	public GameObject barrel2;
	public GameObject barrel3;
	public GameObject barrel4;
	public GameObject barrel5;
	public GameObject barrel6;
	public GameObject barrel7;
	public GameObject barrel8;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;
	public GameObject button5;
	public GameObject button6;
	public GameObject button7;
	public GameObject button8;
	public Text muted;
	public Text speed;

	private int stage;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Mute") == 0) {
			muted.text = "Mute";
		} else {
			muted.text = "Sound On";
		}
		if (PlayerPrefs.GetInt ("CatSpeed") == 0) {
			speed.text = "Cautious Cat";
		} else {
			speed.text = "Stupid Cat";
		}
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		stage = PlayerPrefs.GetInt ("Stage");
		if (stage == 0) {
			button1.SetActive (false);
			button2.SetActive (false);
			button3.SetActive (false);
			button4.SetActive (false);
			button5.SetActive (false);
			button6.SetActive (false);
			button7.SetActive (false);
			button8.SetActive (false);
			barrel1.SetActive (true);
			barrel2.SetActive (true);
			barrel3.SetActive (true);
			barrel4.SetActive (true);
			barrel5.SetActive (true);
			barrel6.SetActive (true);
			barrel7.SetActive (true);
			barrel8.SetActive (true);
		}
		else if (stage == 1) {
			button1.SetActive (true);
			button2.SetActive (false);
			button3.SetActive (false);
			button4.SetActive (false);
			button5.SetActive (false);
			button6.SetActive (false);
			button7.SetActive (false);
			button8.SetActive (false);
			barrel1.SetActive (false);
			barrel2.SetActive (true);
			barrel3.SetActive (true);
			barrel4.SetActive (true);
			barrel5.SetActive (true);
			barrel6.SetActive (true);
			barrel7.SetActive (true);
			barrel8.SetActive (true);
		}
		else if (stage == 2) {
			button1.SetActive (true);
			button2.SetActive (true);
			button3.SetActive (false);
			button4.SetActive (false);
			button5.SetActive (false);
			button6.SetActive (false);
			button7.SetActive (false);
			button8.SetActive (false);
			barrel1.SetActive (false);
			barrel2.SetActive (false);
			barrel3.SetActive (true);
			barrel4.SetActive (true);
			barrel5.SetActive (true);
			barrel6.SetActive (true);
			barrel7.SetActive (true);
			barrel8.SetActive (true);
		}
		else if (stage == 3) {
			button1.SetActive (true);
			button2.SetActive (true);
			button3.SetActive (true);
			button4.SetActive (false);
			button5.SetActive (false);
			button6.SetActive (false);
			button7.SetActive (false);
			button8.SetActive (false);
			barrel1.SetActive (false);
			barrel2.SetActive (false);
			barrel3.SetActive (false);
			barrel4.SetActive (true);
			barrel5.SetActive (true);
			barrel6.SetActive (true);
			barrel7.SetActive (true);
			barrel8.SetActive (true);
		}
		else if (stage == 4) {
			button1.SetActive (true);
			button2.SetActive (true);
			button3.SetActive (true);
			button4.SetActive (true);
			button5.SetActive (false);
			button6.SetActive (false);
			button7.SetActive (false);
			button8.SetActive (false);
			barrel1.SetActive (false);
			barrel2.SetActive (false);
			barrel3.SetActive (false);
			barrel4.SetActive (false);
			barrel5.SetActive (true);
			barrel6.SetActive (true);
			barrel7.SetActive (true);
			barrel8.SetActive (true);
		}
		else if (stage == 5) {
			button1.SetActive (true);
			button2.SetActive (true);
			button3.SetActive (true);
			button4.SetActive (true);
			button5.SetActive (true);
			button6.SetActive (false);
			button7.SetActive (false);
			button8.SetActive (false);
			barrel1.SetActive (false);
			barrel2.SetActive (false);
			barrel3.SetActive (false);
			barrel4.SetActive (false);
			barrel5.SetActive (false);
			barrel6.SetActive (true);
			barrel7.SetActive (true);
			barrel8.SetActive (true);
		}
		else if (stage == 6) {
			button1.SetActive (true);
			button2.SetActive (true);
			button3.SetActive (true);
			button4.SetActive (true);
			button5.SetActive (true);
			button6.SetActive (true);
			button7.SetActive (false);
			button8.SetActive (false);
			barrel1.SetActive (false);
			barrel2.SetActive (false);
			barrel3.SetActive (false);
			barrel4.SetActive (false);
			barrel5.SetActive (false);
			barrel6.SetActive (false);
			barrel7.SetActive (true);
			barrel8.SetActive (true);
		}
		else if (stage == 7) {
			button1.SetActive (true);
			button2.SetActive (true);
			button3.SetActive (true);
			button4.SetActive (true);
			button5.SetActive (true);
			button6.SetActive (true);
			button7.SetActive (true);
			button8.SetActive (false);
			barrel1.SetActive (false);
			barrel2.SetActive (false);
			barrel3.SetActive (false);
			barrel4.SetActive (false);
			barrel5.SetActive (false);
			barrel6.SetActive (false);
			barrel7.SetActive (false);
			barrel8.SetActive (true);
		}
		else if (stage == 8) {
			button1.SetActive (true);
			button2.SetActive (true);
			button3.SetActive (true);
			button4.SetActive (true);
			button5.SetActive (true);
			button6.SetActive (true);
			button7.SetActive (true);
			button8.SetActive (true);
			barrel1.SetActive (false);
			barrel2.SetActive (false);
			barrel3.SetActive (false);
			barrel4.SetActive (false);
			barrel5.SetActive (false);
			barrel6.SetActive (false);
			barrel7.SetActive (false);
			barrel8.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Level1Easy(){
		Application.LoadLevel ("Level1Easy");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void Level1Medium(){
		Application.LoadLevel ("Level1Medium");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void Level1Hard(){
		Application.LoadLevel ("Level1Hard");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	public void Level2Easy(){
		Application.LoadLevel ("Level2Easy");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void Level2Medium(){
		Application.LoadLevel ("Level2Medium");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	public void Level2Hard(){
		Application.LoadLevel ("Level2Hard");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void Level3Easy(){
		Application.LoadLevel ("Level3Easy");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	public void Level3Medium(){
		Application.LoadLevel ("Level3Medium");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void Level3Hard(){
		Application.LoadLevel ("Level3Hard");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	public void MainEasy(){
		Application.LoadLevel ("MainEasy");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void MainMedium(){
		Application.LoadLevel ("MainMedium");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	public void MainHard(){
		Application.LoadLevel ("MainHard");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void home(){
		Application.LoadLevel("Start");
		Screen.orientation = ScreenOrientation.LandscapeLeft;

	}

	public void instructions(){
		panel.SetActive (true);
		panel1.SetActive (false);
	}

	public void closeInstructions(){
		panel.SetActive (false);
		panel1.SetActive (false);
	}

	public void goals(){
		panel.SetActive (false);
		panel1.SetActive (true);
	}

	public void mute(){
		if (PlayerPrefs.GetInt ("Mute") == 0) {
			PlayerPrefs.SetInt ("Mute", 1);
			muted.text = "Sound On";
		} else {
			PlayerPrefs.SetInt ("Mute", 0);
			muted.text = "Mute";
		}
	}

	public void catSpeed(){
		if (PlayerPrefs.GetInt ("CatSpeed") == 0) {
			PlayerPrefs.SetInt ("CatSpeed", 1);
			speed.text = "Stupid Cat";
		} else {
			PlayerPrefs.SetInt ("CatSpeed", 0);
			speed.text = "Cautious Cat";
		}
	}
}
