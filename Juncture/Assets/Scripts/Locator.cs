using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Locator : MonoBehaviour {


		public static float x;
		public static float y;
		public static int f;
		Animator anim;
		Scene s;
		GameObject player;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		//SceneManager.activeSceneChanged += OnSceneChange;
	}
	
	// Update is called once per frame
	void Update () {

				if (s != SceneManager.GetActiveScene ()) {
						OnSceneChange ();
						s = SceneManager.GetActiveScene ();
				}
						
	}

		void OnSceneChange(){

				player = GameObject.FindGameObjectWithTag ("Player");
				player.transform.position = new Vector3 (x, y, 0f);
				anim = player.GetComponent<Animator> ();
				if (f == 0) {
						anim.Play ("IdleFwd");
				} else if (f == 1) {
						anim.Play ("IdleLeft");
				} else if (f == 2) {
						anim.Play ("IdleBck");
				} else {
						anim.Play ("IdleRight");
				}

				print ("Passed");
				print (x + "," + y);
				print (f);
				Destroy (this.gameObject);

		}
}
