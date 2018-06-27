using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public GameObject leftDoor;
	public GameObject rightDoor;

	public AudioSource audioSource;

	public bool locked = true;
	public bool opening = false;

	private Quaternion leftDoorStartRotation;
	private Quaternion leftDoorEndRotation;
	private Quaternion rightDoorStartRotation;
	private Quaternion rightDoorEndRotation;

	public float timer = 0f;
	public float rotationTime = 10f;


	void Start () {
		this.audioSource = GetComponent<AudioSource>();

		this.leftDoorStartRotation = this.leftDoor.transform.rotation;
		this.leftDoorEndRotation = this.leftDoorStartRotation * Quaternion.Euler(0, 0, -100);

		this.rightDoorStartRotation = this.rightDoor.transform.rotation;
		this.rightDoorEndRotation = this.rightDoorStartRotation * Quaternion.Euler(0, 0, 100);
	}


	void Update () {

		if (this.opening)
		{
			this.leftDoor.transform.rotation = Quaternion.Slerp(this.leftDoorStartRotation, this.leftDoorEndRotation, this.timer / this.rotationTime);

			this.rightDoor.transform.rotation = Quaternion.Slerp(this.rightDoorStartRotation, this.rightDoorEndRotation, this.timer / this.rotationTime);
		
			this.timer += Time.deltaTime;
		}
	}


	public void OnDoorClicked () {
		/// Called when the 'Left_Door' or 'Right_Door' game object is clicked
		/// - Starts opening the door if it has been unlocked
		/// - Plays an audio clip when the door starts opening

		// Prints to the console when the method is called
		Debug.Log ("'Door.OnDoorClicked()' was called");

		// TODO: If the door is unlocked, start animating the door rotating open and play a sound to indicate the door is opening
		// Use 'locked' to check if the door is locked and ...
		if (!this.locked)
		{
			// ... start the animation defined in Update() by changing the value of 'opening'
			this.opening = true;
			// ... use 'audioSource' to play the AudioClip assigned to the AudioSource component
			this.audioSource.Play();
		}


		// OPTIONAL-CHALLENGE: Prevent the door from being interacted with after it has started opening
		// TIP: You could disable the Event Trigger component, or for an extra challenge, try disabling all the Collider components on all children
		

		// OPTIONAL-CHALLENGE: Play a different sound if the door is locked
		// TIP: You could get a reference to the 'Door_Locked' audio and play it without assigning it to the AudioSource component
	}


	public void Unlock () {
		Debug.Log ("'Door.Unlock()' was called");
		this.locked = false;
	}
}
