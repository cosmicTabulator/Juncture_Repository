using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

		Animator anim;

		Rigidbody2D body;

		Vector2 dir;

		Vector2 pos;

		Transform trans;

		System.Random r = new System.Random();
		int start;
		int current;
		bool mov;
		bool running;
		int diff;
		int state;
		int facing;
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

				trans = GetComponent<Transform> ();

				upper = levels.Length;
				level = orgin;
				print (upper);
				print ("level" + level);

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
			facing = 0;
		} else {
			anim.SetBool ("MoveDown", false);	
		}

		if (y > 0) {
			anim.SetBool("MoveUp", true);
			anim.SetInteger ("Facing", 2);
			facing = 2;
		}else {
			anim.SetBool ("MoveUp", false);	
		}

		if (x > 0) {
			anim.SetBool("MoveRight", true);
			anim.SetInteger ("Facing", 3);
			facing = 3;
		}else {
			anim.SetBool ("MoveRight", false);	
		}

		if (x < 0) {
			anim.SetBool("MoveLeft", true);
			anim.SetInteger ("Facing", 1);
			facing = 1;
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

				if (facing == 0) {
						dir = Vector2.down;
						pos = new Vector2 (trans.position.x, trans.position.y - 1.25f);
				}
				if (facing == 1) {
						dir = Vector2.left;
						pos = trans.position;
				}
				if (facing == 2) {
						dir = Vector2.up;
						pos = new Vector2 (trans.position.x, trans.position.y - 0.7f);
				}
				if (facing == 3) {
						dir = Vector2.right;
						pos = trans.position;
				}

				RaycastHit2D hit = Physics2D.Raycast (pos, dir, 1f);
				if (hit.collider != null) {
						if (Input.GetKeyDown (KeyCode.F)) {
								GameObject wanted = hit.collider.gameObject;
								wanted.SendMessage ("Interact");
								print (wanted.name);
						}


				}
				Debug.DrawRay (pos, dir);

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
				
						print ("i" + i);
						print ("i" + (i + 1));
						print ("upper" + upper);

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

				case 00:
						//anim.runtimeAnimatorController = Resources.Load ("Textures/Sprites/Entities/Char/C1_Char/C1_L1_Char/Char1_Light1") as RuntimeAnimatorController;	
						break;
				case 01:
						anim.runtimeAnimatorController = Resources.Load ("Textures/Sprites/Entities/Char/C0Char/L1/Char0_Light1") as RuntimeAnimatorController;
						break;
				case 10:
						//anim.runtimeAnimatorController = Resources.Load ("Textures/Sprites/Entities/Char/C2_Char/C2_L1_Char/Char2_Light1") as RuntimeAnimatorController;
						break;
				case 11:
						anim.runtimeAnimatorController = Resources.Load ("Textures/Sprites/Entities/Char/C1Char/L1/Char1_Light1") as RuntimeAnimatorController;
						break;
				}

		}

		private void tick(object sender, System.Timers.ElapsedEventArgs e)
		{
				current++;
		}
}
