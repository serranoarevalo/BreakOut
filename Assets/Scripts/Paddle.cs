using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public float PaddleSpeed = 1f;
	private Vector3 playerPos = new Vector3(0f, -9f, 0f);

	void Update(){
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * PaddleSpeed );

		playerPos = new Vector3 (Mathf.Clamp (xPos, -9f, 9f), -9f, 0f);

		transform.position = playerPos;
	}
}