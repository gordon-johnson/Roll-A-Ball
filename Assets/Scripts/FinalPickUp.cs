using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPickUp : MonoBehaviour
{
	public GameObject finalPickUp;

	private float spawnX = 0f;
	private float spawnY = 11f;
	private float spawnZ = -10f;

	void Update()
    {
        if (PlayerController.count >= 21)
		{
			finalPickUp.transform.position = new Vector3(spawnX, spawnY, spawnZ);
		}
    }
}
