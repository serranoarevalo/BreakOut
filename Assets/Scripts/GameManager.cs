using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

	void CheckGameOver() {
		if (Bricks <= 1) {
			if (YouWon != null) {
				YouWon.SetActive (true);
				Time.timeScale = 0.25f;

				Invoke ("Reset", ResetDelay);
			}
		}

		if (Lives < 1) {
			if (GameOver != null) {
				GameOver.SetActive (true);
				Time.timeScale = 0.25f;
				Invoke ("Reset", ResetDelay);
			}
		}
	}

	void Reset(){
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoseLife(){
		Lives--;
		if (TxtLives != null) {
			TxtLives.text = "Lives: " + Lives;
			Destroy (clonePaddle.gameObject);
			Invoke ("SetupPaddle", ResetDelay);
			CheckGameOver ();
		}
	}

	public void SetupPaddle() {
		clonePaddle = Instantiate (Paddle, Paddle.transform.position, Quaternion.identity) as GameObject;	
	}

	public void DestroyBrick(){
		Bricks--;
		CheckGameOver ();
	}
}
