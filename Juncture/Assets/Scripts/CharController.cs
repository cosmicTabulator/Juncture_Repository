using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

		Animator anim;

		Rigidbody2D body;

		System.Random r = new System.Random();
		int start;
		int current;
		bool mov;
		bool running;
		int diff;
		int state;
		int level;
		int i;
		int upper;
		public int orgin;
		public int[] levels = new int[0];

	// Use this for initialization
	void Start () {

				System.Timers.Timer aTimer = new System.Timers.Timer(1000);
				aTimer.Elapsed += new System.Timers.ElapsedEventHandler (tick);
				aTimer.Enabled=true;
				anim = GetComponent<Animator> ();

				body = GetComponent<Rigidbody2D> ();

				upper = levels.Length;
				level = orgin;

				//body.freezeRotation = true;
	

	}
	
	// Update is called once per frame
	void Update () {

		anim.SetInteger ("Idle", 0);

		float x;
		float y;
		float factor = 3.0f;

		x = Input.GetAxisRaw ("Horizontal");
		y = Input.GetAxisRaw ("Vertical");

		if (y < 0) {
			anim.SetBool ("MoveDown", true);
			anim.SetInteger ("Facing", 0);
		} else {
			anim.SetBool ("MoveDown", false);	
		}

		if (y > 0) {
			anim.SetBool("MoveUp", true);
			anim.SetInteger ("Facing", 2);
		}else {
			anim.SetBool ("MoveUp", false);	
		}

		if (x > 0) {
			anim.SetBool("MoveRight", true);
			anim.SetInteger ("Facing", 3);
		}else {
			anim.SetBool ("MoveRight", false);	
		}

		if (x < 0) {
			anim.SetBool("MoveLeft", true);
			anim.SetInteger ("Facing", 1);
		}else {
			anim.SetBool ("MoveLeft", false);	
		}

		if ((x != 0) || (y != 0)) {
			anim.SetBool ("Moving", true);
			mov = true;
			running = false;
		} else {
			anim.SetBool ("Moving", false);
			mov = false;
		}

		Vector2 v = new Vector2(x,y);
		body.velocity = v * factor;



		if(mov == false){
			if (running) {
				diff = current - start;
				if (diff < 0) {
					diff += 60;
				}
				if (diff >= 3) {
					state = r.Next (1, 4);
					switch (state) {

					case 1:
						anim.SetInteger ("Idle", 1);
						break;
					case 2:
						anim.SetInteger ("Idle", 2);
						break;
					case 3:
						anim.SetInteger ("Idle", 3);
						break;

					}
	
					start = current;
		
				}
	
			} else {
				running = true;
				start = current;
			}


		}

		if (Input.GetKeyDown(KeyCode.Q)) {

				if (i - 1 > -1) {
						i--;
						print ("i" + i);
						level = levels [i];
						getAnim (level);
						body.transform.Translate (0f, -100f, 0f);
				}

		}
		if (Input.GetKeyDown(KeyCode.E)) {

				if(i+1 < upper){
						i++;
						print ("i" + i);
						level = levels [i];
						getAnim (level);
						body.transform.Translate (0f, 100f, 0f);
				}


		}

	}

		private void getAnim(int level){
				print ("Level" + level);
				switch (level) {

				case 11:
						//anim.runtimeAnimatorController = Resources.Load ("Textures/Sprites/Entities/Char/C1_Char/C1_L1_Char/Char1_Light1") as RuntimeAnimatorController;	
						break;
				case 12:
						//anim.runtimeAnimatorController = Resources.Load ("Textures/Sprites/Entities/Char/C1_Char/C1_L2_Char/Char1_Light2") as RuntimeAnimatorController;
						break;
				case 21:
						//anim.runtimeAnimatorController = Resources.Load ("Textures/Sprites/Entities/Char/C2_Char/C2_L1_Char/Char2_Light1") as RuntimeAnimatorController;
						break;
				}

		}

		private void tick(object sender, System.Timers.ElapsedEventArgs e)
		{
				current++;
		}
}
