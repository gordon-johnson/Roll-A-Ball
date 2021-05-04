using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	public static int count;
	private bool grounded;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float fallThreshold = -10;

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		Vector3 jump = new Vector3(0.0f, 1.0f, 0.0f);

		/* === Move Mechanic === */

		rb.AddForce(movement * speed);

		/* === Jump Mechanic === */

		if (Input.GetKey(KeyCode.Space) && grounded)
		{
			rb.AddForce(jump * jumpForce);
		}

		/* === Falling-Reset Mechanic === */

		if (transform.position.y < fallThreshold)
		{
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			++count;
			SetCountText();
		}
	}

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			grounded = true;
			Debug.Log("grounded");
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			grounded = false;
			Debug.Log("airborne");

		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 22)
		{
			winText.text = "You Win!";
		}
	}
}
