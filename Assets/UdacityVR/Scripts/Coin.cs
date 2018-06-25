using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public GameObject coinPoofPrefab;
	public int rotationSpeed = 25;
	public float destroyAfterSeconds = 0.5f;

	void Update () {
		this.transform.Rotate(new Vector3(0, this.rotationSpeed, 0) * Time.deltaTime);
	}


	public void OnCoinClicked () {
		Debug.Log ("'Coin.OnCoinClicked()' was called");

		Instantiate(this.coinPoofPrefab, this.transform.position, this.coinPoofPrefab.transform.rotation);

		Destroy(this.gameObject, this.destroyAfterSeconds);
	}
}
