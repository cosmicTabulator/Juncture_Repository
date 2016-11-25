using UnityEngine;
using System.Collections;

public class TomeTable : MonoBehaviour {

	Renderer r;
	Animator anim;

	// Use this for initialization
	void Start () {
	
		r = GetComponent<Renderer> ();
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void OnTriggerEnter2D(Collider2D other) {
				r.sortingLayerName = "AboveChar";
				print ("Enter");
		}

	void OnTriggerExit2D(Collider2D other){
				r.sortingLayerName = "BelowChar";
				print ("Exit");
	}

		void Interact(){

				anim.SetTrigger ("Turn");

		}
}
