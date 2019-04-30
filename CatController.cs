using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CatController : MonoBehaviour {
	
	public float speed;
	public Text lose;
	public GameObject mouse;
	public AudioClip mouseLost;
	public AudioClip mouseCaught;
	public AudioClip meow1;
	public AudioClip meow2;

	private Rigidbody2D rb;
	private Vector2 movement;
	private Vector3 target;
	private Vector3 temp;
	private bool start;
	private bool caught;
	private AudioSource source;
	private bool played;
	
	void Start(){
		lose.text = "";
		rb = GetComponent<Rigidbody2D> ();
		source = GetComponent<AudioSource> ();
		target = mouse.transform.position;
		start = false;
		caught = false;
		StartCoroutine (delay ());
		played = false;
		StartCoroutine (meowTime ());
		if (PlayerPrefs.GetInt ("CatSpeed") == 1) {
			StartCoroutine (dash ());
		}
	}

	void Update(){
		if (start == true) {
			if(PlayerPrefs.GetInt("CatSpeed") == 0){
			target = mouse.transform.position;
			rb.velocity = (speed * (target - transform.position));
			}
			float moveHorizontal = 10 * Input.GetAxis ("Horizontal");
			float moveVertical = 10 * Input.GetAxis ("Vertical");
			temp = transform.eulerAngles;
			if ((mouse.transform.position.x - transform.position.x) > 0) {
				transform.eulerAngles = new Vector3 (0, 0, (180 * Mathf.Atan ((mouse.transform.position.y - transform.position.y) / (mouse.transform.position.x - transform.position.x)) / Mathf.PI) - 90);
			} else if ((mouse.transform.position.x - transform.position.x) < 0) {
				transform.eulerAngles = new Vector3 (0, 0, 90 + (180 * Mathf.Atan ((mouse.transform.position.y - transform.position.y) / (mouse.transform.position.x - transform.position.x)) / Mathf.PI));
			} else if ((mouse.transform.position.x - transform.position.x) == 0 && (mouse.transform.position.y - transform.position.y) < 0) {
				transform.eulerAngles = new Vector3 (0, 0, 180);
			} else if ((mouse.transform.position.x - transform.position.x) == 0 && (mouse.transform.position.y - transform.position.y) > 0) {
				transform.eulerAngles = new Vector3 (0, 0, 0);
			} else if ((mouse.transform.position.x - transform.position.x) == 0 && (mouse.transform.position.y - transform.position.y) == 0) {
				transform.eulerAngles = temp;
			}
		}
		if (mouse.activeSelf == false && played == false) {
			if(PlayerPrefs.GetInt("Mute") == 0){
				source.PlayOneShot (mouseLost, 1);
			}
			played = true;
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Mouse")) {
			caught = true;
			if(PlayerPrefs.GetInt("Mute") == 0){
				source.PlayOneShot (mouseCaught, 1);
			}
			other.gameObject.GetComponent<MouseController>().caught();
			lose.text = "You were caught! No more cheese for you!";
		}
		if (other.gameObject.CompareTag ("Wall") && PlayerPrefs.GetInt("CatSpeed") == 1) {
			target = mouse.transform.position;
			rb.velocity = (speed * 2.0f * (target - transform.position));
		}
	}

	IEnumerator delay(){
		yield return new WaitForSeconds (3);
		start = true;
		if (PlayerPrefs.GetInt ("Mute") == 0) {
			source.PlayOneShot (meow1, 1);
		}
	}
	
	IEnumerator meowTime(){
		yield return new WaitForSeconds (4);
		if (PlayerPrefs.GetInt ("Mute") == 0) {
			source.PlayOneShot (meow2, 0.5f);
		}
		int randomInt = Random.Range(1,21);
		if (mouse.activeSelf == true) {
			if (randomInt < 11) {
				StartCoroutine (meowTime1 ());
			} else {
				StartCoroutine (meowTime ());
			}
		}
	}

	IEnumerator meowTime1(){
		yield return new WaitForSeconds (5);
		if (PlayerPrefs.GetInt ("Mute") == 0) {
			source.PlayOneShot (meow1, 0.5f);
		}
		int randomInt = Random.Range(1,21);
		if (mouse.activeSelf == true) {
			if (randomInt < 11) {
				StartCoroutine (meowTime1 ());
			} else {
				StartCoroutine (meowTime ());
			}
		}
	}
	IEnumerator dash(){
		yield return new WaitForSeconds (3);
		target = mouse.transform.position;
		rb.velocity = (speed * 2.0f * (target - transform.position));
	}
}