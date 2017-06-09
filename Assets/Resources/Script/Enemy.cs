using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Rigidbody2D rb; 
	public float speed,speed2; 
	GameObject tiro; 
	public GameObject[] powerUps;
	public static int score;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		tiro = Resources.Load ("Prefab/shootEnemy") as GameObject;

	}
	

	void Update () {
		speed2 = 100;
		transform.Rotate (Vector3.forward * Time.deltaTime * speed2);
		if (Random.Range (0, 11f) < 0.1f) {
			Instantiate(tiro,new Vector3(transform.position.x -1 ,transform.position.y,0),Quaternion.identity);
		}

		rb.velocity = Vector3.left * speed;

		/*if (boss.bossLife) {
	coll.gameObject.GetComponent<SpriteRenderer>().color= Color.Lerp(Color.red,Color.white, Mathf.PingPong(Time.time, 1));
		}*/
	}


	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.transform.tag.Equals ("shoot") || coll.transform.tag.Equals ("Player") || coll.transform.tag.Equals ("EnemyLimit")) {
			gameObject.SetActive (false);


			if (!coll.transform.tag.Equals ("EnemyLimit") && !coll.transform.tag.Equals ("Player")) {
				int randon = Random.Range (0, 10);

				score += 50;
				if (randon == 5)
					Instantiate (powerUps [Random.Range (0, powerUps.Length)], transform.position, Quaternion.identity);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D outro)
	{
		if (outro.gameObject.tag.Equals ("ShildPW")) {
			outro.gameObject.SetActive(false);
			Destroy(gameObject);
			PlayerMove.ShieldPW = false; 
		}
	}



}