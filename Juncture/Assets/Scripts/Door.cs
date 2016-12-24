using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

		public string scene;
		public float xDisp;
		public float yDisp;
		public int facing;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
	
				UnityEngine.SceneManagement.SceneManager.LoadScene (scene, UnityEngine.SceneManagement.LoadSceneMode.Single);
				Locator.x = xDisp;
				Locator.y = yDisp;
				Locator.f = facing;
				

	}
}
