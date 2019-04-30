using UnityEngine;
using System.Collections;

public class MouseTrapController : MonoBehaviour {

	public GameObject sprung;
	public GameObject unsprung;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Mouse")) {
			sprung.SetActive(true);
			unsprung.SetActive(false);
		}
	}
}
