using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject[] spawnPoints;
	public GameObject player;

	void Start ()
	{
		int index = Random.Range(0, this.spawnPoints.Length);

		this.player.transform.position = this.spawnPoints[index].transform.position;
	}
}
