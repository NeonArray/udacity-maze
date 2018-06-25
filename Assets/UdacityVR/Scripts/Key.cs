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

		this.door.GetComponentInChildren<Door>().Unlock();

		Instantiate(this.keyPoofPrefab, this.transform.position, this.keyPoofPrefab.transform.rotation);

		Destroy(this.gameObject, this.destroyAfterSeconds);
	}
}
