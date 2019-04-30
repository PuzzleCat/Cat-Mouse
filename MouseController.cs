using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseController : MonoBehaviour {
	
	public float speed;
	public Text cheeseCount;
	public Text score;
	public GameObject mouse;
	public GameObject mouseRunning;
	public GameObject mouseBike;
	public GameObject bike;
	public Text begin;
	public AudioClip mouseBump;
	public AudioClip mouseCaught;
	public Text level;
	
	private Rigidbody2D rb;
	private int cCount;
	private Vector3 temp;
	private bool move;
	private Vector3 target;
	private Vector3 original;
	private Vector3 path;
	private bool start;
	private float oSpeed;
	private AudioSource source;
	
	void Start(){
		rb = GetComponent<Rigidbody2D>();
		source = GetComponent<AudioSource> ();
		cCount = 0;
		cheeseCount.text = "Cheeses: 0";
		score.text = "";
		move = true;
		target = new Vector3(0, 100, 0);
		start = false;
		original = transform.position;
		begin.text = "3";
		StartCoroutine (delay2 ());
		StartCoroutine(delay());
	}
	
	void Update () {
		if (start == true && move == true) {
			temp = transform.eulerAngles;
			original = transform.position;
			path = target - original;
			if (Input.GetMouseButtonDown (0)) {
				target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				target.z = transform.position.z;
			}
			if(PlayerPrefs.GetInt("CatSpeed") == 1){
				transform.position = Vector3.MoveTowards (transform.position, target, speed * 2.0f * Time.deltaTime);
			}
			else{
				transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
			}
			if (path.x == 0) {
				if (path.y > 0) {
					transform.eulerAngles = new Vector3 (0, 0, 0);
				} else if (path.y < 0) {
					transform.eulerAngles = new Vector3 (0, 0, 180);
				} else if (path.y == 0) {
					transform.eulerAngles = temp;
				}
			} else {
				if (path.x > 0) {
					transform.eulerAngles = new Vector3 (0, 0, (180 * Mathf.Atan (path.y / path.x) / Mathf.PI) - 90);
				} else if (path.x < 0) {
					transform.eulerAngles = new Vector3 (0, 0, (180 * Mathf.Atan (path.y / path.x) / Mathf.PI) + 90);
				}
			}
			if (path.x == 0 && path.y == 0) {
				mouseRunning.SetActive (false);
				mouse.SetActive (true);
			} else {
				mouseRunning.SetActive (true);
				mouse.SetActive (false);
			}
		}
	}    
	
	void OnTriggerEnter2D(Collider2D other){
		if(PlayerPrefs.GetInt("Mute") == 0){
			source.PlayOneShot (mouseBump, 1);
		}
		if (other.gameObject.CompareTag ("Cheese")) {
			cCount = cCount + 1;
			cheeseCount.text = "Cheeses: " + cCount;
		} else if (other.gameObject.CompareTag ("BadCheese")) {
			cCount = cCount + 1;
			cheeseCount.text = "Cheeses: " + cCount;
			oSpeed = speed;
			speed = speed * 0.5f;
			StartCoroutine (trapped2 ());
		} else if (other.gameObject.CompareTag ("Hole") && move == true) {
			score.text = "You survived!";
			if(cCount > 19 && level.text == "1-1" && PlayerPrefs.GetInt("Stage") == 0){
				PlayerPrefs.SetInt("Stage", 1);
			}
			else if(cCount > 15 && level.text == "1-2" && PlayerPrefs.GetInt("Stage") == 1){
				PlayerPrefs.SetInt("Stage", 2);
			}
			else if(cCount > 11 && level.text == "1-3" && PlayerPrefs.GetInt("Stage") == 2){
				PlayerPrefs.SetInt("Stage", 3);
			}
			else if(cCount > 19 && level.text == "2-1" && PlayerPrefs.GetInt("Stage") == 3){
				PlayerPrefs.SetInt("Stage", 4);
			}
			else if(cCount > 15 && level.text == "2-2" && PlayerPrefs.GetInt("Stage") == 4){
				PlayerPrefs.SetInt("Stage", 5);
			}
			else if(cCount > 11 && level.text == "2-3" && PlayerPrefs.GetInt("Stage") == 5){
				PlayerPrefs.SetInt("Stage", 6);
			}
			else if(cCount > 19 && level.text == "3-1" && PlayerPrefs.GetInt("Stage") == 6){
				PlayerPrefs.SetInt("Stage", 7);
			}
			else if(cCount > 15 && level.text == "3-2" && PlayerPrefs.GetInt("Stage") == 7){
				PlayerPrefs.SetInt("Stage", 8);
			}
			PlayerPrefs.Save();
			gameObject.SetActive (false);
			target = transform.position;
		} else if (other.gameObject.CompareTag ("MouseTrap")) {
			if(PlayerPrefs.GetInt("Mute") == 0){
				source.PlayOneShot (mouseCaught, 1);
			}
			move = false;
			StartCoroutine (trapped ());
		} else if (other.gameObject.CompareTag ("Bike")) {
			other.gameObject.SetActive(false);
			mouseRunning.SetActive (false);
			mouseBike.SetActive (true);
			oSpeed = speed;
			speed = speed * 2.0f;
			StartCoroutine(bikeTime());
			StartCoroutine(bikeRespawn());
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("MouseTrap")) {
			other.gameObject.SetActive (false);
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Cat")) {
			move = false;
			if(PlayerPrefs.GetInt("Mute") == 0){
				source.PlayOneShot (mouseCaught, 1);
			}
		}
		if (PlayerPrefs.GetInt ("Mute") == 0) {
			source.PlayOneShot (mouseBump, 1);
		}
	}
	
	public void caught(){
		move = false;
	}
	
	IEnumerator delay(){
		yield return new WaitForSeconds (3);
		start = true;
		begin.text = "Start!";
		StartCoroutine (endDelay ());
	}
	
	IEnumerator endDelay(){
		yield return new WaitForSeconds (1);
		begin.text = "";
	}
	
	IEnumerator delay2(){
		yield return new WaitForSeconds (1);
		begin.text = "2";
		StartCoroutine (delay3 ());
	}
	
	IEnumerator delay3(){
		yield return new WaitForSeconds (1);
		begin.text = "1";
	}

	IEnumerator trapped(){
		yield return new WaitForSeconds (1);
		move = true;
	}

	IEnumerator trapped2(){
		yield return new WaitForSeconds (2);
		speed = oSpeed;
	}

	IEnumerator bikeTime(){
		yield return new WaitForSeconds (10);
		speed = oSpeed;
		mouse.SetActive (true);
		mouseBike.SetActive (false);
	}

	IEnumerator bikeRespawn(){
		yield return new WaitForSeconds (5);
		bike.SetActive (true);
	}
	
}