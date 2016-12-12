using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Locator : MonoBehaviour {


		public static float x;
		public static float y;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
				SceneManager.activeSceneChanged += OnSceneChange;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void OnSceneChange(){


		}
}
