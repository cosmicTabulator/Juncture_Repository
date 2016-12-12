using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Locator : MonoBehaviour {


		public static float x;
		public static float y;
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

				print ("Passed");
				print (x + "," + y);
				Destroy (this.gameObject);

		}
}
