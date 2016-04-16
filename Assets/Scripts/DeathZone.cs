using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	void OnTriggerEnter(){
		GameManager.Instance.LoseLife ();
	}
}
