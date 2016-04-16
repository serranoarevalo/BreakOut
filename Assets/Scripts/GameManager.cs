using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int Lives = 3;
	public int Bricks = 24;
	public float ResetDelay;
	public Text TxtLives = null;
	public GameObject GameOver = null;
	public GameObject YouWon = null;
	public GameObject BricksPrefab = null;
	public GameObject Paddle = null;

	public static GameManager Instance = null;

	private GameObject clonePaddle = null;

	void Start() {
		
		if (Instance == null) {
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}

		SetUp ();
	}

	public void SetUp(){
		if (Paddle != null) {
			clonePaddle = Instantiate (Paddle, Paddle.transform.position, Quaternion.identity) as GameObject;
		}
		if (BricksPrefab != null) {
			Instantiate (BricksPrefab, BricksPrefab.transform.position, Quaternion.identity);
		}
	}

}
