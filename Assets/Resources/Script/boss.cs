using UnityEngine;
using System.Collections;

public class boss : MonoBehaviour {

	static public int bossLife;
	public GameObject Boss;

	void Start () {
		bossLife = 10;	
	}

	void Update () {

		if (bossLife == 0) {
			Boss.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag.Equals ("ShildPW")) {
			Destroy(coll.gameObject);
			PlayerMove.ShieldPW = false ;
		}
	}
}
