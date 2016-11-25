using UnityEngine;
using System.Collections;

public class ClockBehavior : MonoBehaviour {

		Animator anim;

		int level;
		int i;
		int upper;
		public int orgin;
		public int[] levels = new int[0];

	// Use this for initialization
	void Start () {
	
				anim = GetComponent<Animator> ();
				upper = levels.Length;

	}
	
	// Update is called once per frame
	void Update () {
	
				if (Input.GetKeyDown(KeyCode.Q)) {

						if (i - 1 > -1) {
								i--;
								print ("i" + i);
								level = levels [i];
								anim.SetInteger ("level", level);
						}

				}
				if (Input.GetKeyDown(KeyCode.E)) {

						if(i+1 < upper){
								i++;
								print ("i" + i);
								level = levels [i];
								anim.SetInteger ("level", level);
						}


				}

	}
				
}
