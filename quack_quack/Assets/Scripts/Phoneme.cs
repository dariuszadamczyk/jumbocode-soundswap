using UnityEngine;
using System.Collections;


public class Phoneme : MonoBehaviour {
	private bool wasDragged = false;
	private static bool phonemePlaying = false;
	private AudioSource audio;
	private Camera cam;
	public float range  = 100.0f;
	public float waitTime = 0.4f;
	public float bounceBackSpeed = 1.0f;
	// Use this for initialization
	void Start () {
		// NOTE: Turn off play on awake property manually in Editor, 
		// the below code does NOT Prevent it from playing on startup
		cam = Camera.main;
		audio = GetComponent<AudioSource>();
		audio.playOnAwake = false;

		// TODO: Get list of all gameobjects with tag Unfilled_Word
		// TODO: grab initial position, to use in bounce back
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// 
	/*
	 * http://answers.unity3d.com/questions/12322/drag-gameobject-with-mouse.html
	 * 
	 */
	void OnMouseDrag()
	{
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
		                                                                Input.mousePosition.y, distance_to_screen ));
		wasDragged = true;
	}
	void OnMouseUp() {
		// if was dragged
		// if over word & valid, enter
		// else bounce back to word bank
		if (wasDragged) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			
			Ray ray = cam.ScreenPointToRay(new Vector3(x, y));
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit, range)) {
				if (hit.collider.tag == "Unfilled_Word") {
					GameObject[] unfilledWords = GameObject.FindGameObjectsWithTag ("Unfilled_Word");;
					GameObject target = null;
					foreach (GameObject word in unfilledWords) {
						if (hit.Equals(word)) {
							target = word;
							break;
						}
					}
					if (target != null) {
						// cast as Word
						// call completesWord()
					} else {
						// TODO: exception
					}
					//hit.Equals()
					// iterate through all Unfiled Word game objects
					// if hit.Equals(), break, else if iterate thru all and fidn nothing raise exception
					// 
					wasDragged = false;
				}
			}
		}
		wasDragged = false;
		bounceBack ();
	}


	void OnMouseDown() {
		audio.Play ();
		// StartCoroutine (playPhoneme());
	}

	/*
	 * Should I have the waitTime bvetween audio clips?
	 */
	IEnumerator playPhoneme() {
 		AudioSource audio = GetComponent<AudioSource>();
		if (phonemePlaying == false) {
			yield return new WaitForSeconds (waitTime);
		}
		phonemePlaying = true;
		Debug.Log ("Calling play phoneme");
		audio.Play ();
		yield return new WaitForSeconds(waitTime);
		phonemePlaying = false;
	}
	void bounceBack() {
		// return to word bank using init position and bounceBackSpeed
		// turn off interactivity?
	}

}
