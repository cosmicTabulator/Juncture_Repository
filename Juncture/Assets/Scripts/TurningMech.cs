using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurningMech : MonoBehaviour {

		SpriteRenderer spr;

		public Dictionary<int, Sprite> dictSprites = new Dictionary<int, Sprite>();
		public Sprite[] textures;
		public Sprite texture1;
		public Sprite texture2;

	// Use this for initialization
	void Start () {
	
				Sprite[] textures = Resources.LoadAll<Sprite> ("Textures/Sprites/TurningMech");
				texture1 = Resources.Load<Sprite> ("Assets/Textures/Sprites/TurningMech_0");
				texture2 = Resources.Load<Sprite> ("Assets/Textures/Sprites/TurningMech_1");
				int i = 0;
				foreach (Sprite s in textures) {
						dictSprites.Add (i, s);
						i++;
				}
				spr = GetComponent<SpriteRenderer> ();
				print (textures.Length);

	}
	
	// Update is called once per frame
	void Update () {
	
				if(Input.GetKeyDown(KeyCode.Alpha1)){spr.sprite = dictSprites[0];}
				if(Input.GetKeyDown(KeyCode.Alpha2)){spr.sprite = dictSprites[1];}
				if(Input.GetKeyDown(KeyCode.Alpha3)){spr.sprite = dictSprites[2];}

}
}