using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public GameObject keyPoofPrefab;
	public GameObject door;
	public int rotationSpeed = 25;
	public float destroyAfterSeconds = 0.5f;

	void Update () {
		this.transform.Rotate(new Vector3(0, 0, this.rotationSpeed) * Time.deltaTime);
	}


	public void OnKeyClicked () {

		Debug.Log ("'Key.OnKeyClicked()' was called");

		// TODO: Unlock the door, display the poof effect, and remove the key from the scene
		// Use 'door' to call the Door.Unlock() method
		this.door.GetComponentInChildren<Door>().Unlock();

		// Use Instantiate() to create a clone of the 'KeyPoof' prefab at this coin's position and with the 'KeyPoof' prefab's rotation
		Instantiate(this.keyPoofPrefab, this.transform.position, this.keyPoofPrefab.transform.rotation);

		// Use Destroy() to delete the key after for example 0.5 seconds
		Destroy(this.gameObject, this.destroyAfterSeconds);
	}
}
