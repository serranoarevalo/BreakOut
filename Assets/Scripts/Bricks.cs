using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public GameObject BrickParticle = null;

	void OnCollisionEnter(Collision other){
		if (BrickParticle != null) {
			Instantiate (BrickParticle, transform.position, Quaternion.identity);
		}

		GameManager.Instance.DestroyBrick ();
		Destroy (gameObject);
	}
}
