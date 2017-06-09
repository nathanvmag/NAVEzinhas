using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	public float speed; 

	void Start () {
	
	}
	

	void Update () {
		transform.Translate (Vector3.right *speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Limit") {
			gameObject.SetActive (false);
		}
		
		if (coll.gameObject.tag.Equals ("ShildPW")&& speed < 0) {
			coll.gameObject.SetActive(false);
			Destroy(gameObject);
			PlayerMove.ShieldPW = false ; 
		}

	}
		
	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag.Equals ("Player") && speed < 0) {
			gameObject.SetActive (false);
		}

		if (coll.gameObject.tag.Equals ("Enemy") && speed > 0) {
			gameObject.SetActive (false);
		}

		if (coll.gameObject.tag.Equals ("Enemy") && speed < 0) {
			Destroy(gameObject);
		}

		if (coll.gameObject.tag == "EnemyLimit") {
			Destroy(gameObject); 
		}

		if (coll.gameObject.tag.Equals ("Tentacles") && speed > 0) {
			gameObject.SetActive (false);
		}

		if (coll.gameObject.tag.Equals ("Head") && speed > 0) {
			boss.bossLife--;
			Enemy.score+=20;
			coll.gameObject.GetComponent<SpriteRenderer>().color= Color.Lerp(Color.red,Color.white, Mathf.PingPong(Time.time, 1));
			gameObject.SetActive (false);
		}

		if (coll.gameObject.tag.Equals ("BossHead") && speed > 0) {
			FinalBoss.FinalBossLife--;
			Enemy.score+=20;
			coll.gameObject.GetComponent<SpriteRenderer>().color= Color.Lerp(Color.red,Color.white, Mathf.PingPong(Time.time, 1));
			gameObject.SetActive (false);
		}
	}

}	
		
	

