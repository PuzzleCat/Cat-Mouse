using UnityEngine;
using System.Collections;

public class CheeseController : MonoBehaviour {

	public GameObject SquashedCheese;
	public GameObject GoodCheese;

	private bool squashed;
	private bool eaten;

	// Use this for initialization
	void Start () {
		squashed = false;
		eaten = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Cat") && squashed == false && eaten == false) {
			SquashedCheese.SetActive (true);
			GoodCheese.SetActive (false);
			squashed = true;
			gameObject.GetComponent<PolygonCollider2D>().enabled = false;
		}
		if (other.gameObject.CompareTag ("Mouse") && squashed == false) {
			GoodCheese.SetActive (false);
			eaten = true;
			gameObject.SetActive(false);
		}

	}
}
