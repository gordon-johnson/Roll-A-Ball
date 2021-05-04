using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
	private float minScaleSize = 0.95f;
	private float maxScaleSize = 1.05f;
	private float speed = 10f;

	private Vector3 minScale;
	private Vector3 maxScale;
	private Vector3 scaleSpeed;

	void Start()
	{
		minScale = transform.localScale * minScaleSize;
		maxScale = transform.localScale * maxScaleSize;
		scaleSpeed = new Vector3(1f, 1f, 1f) * speed;
	}

	void Update()
    {
		if (transform.localScale.x <= minScale.x || transform.localScale.x >= maxScale.x)
		{
			scaleSpeed *= -1;
		}

		transform.localScale = transform.localScale + scaleSpeed * Time.deltaTime / 100;
	}
}
