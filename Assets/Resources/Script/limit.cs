using UnityEngine;
using System.Collections;

public class limit : MonoBehaviour {


	void  OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy")
			coll.gameObject.SetActive (false);
	}
	void  OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy")
			coll.gameObject.SetActive (false);
	}
}

