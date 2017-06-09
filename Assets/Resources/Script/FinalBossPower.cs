using UnityEngine;
using System.Collections;

public class FinalBossPower : MonoBehaviour {
	
	//Rigidbody2D rb; 
	//public float speed; 
	GameObject tiro; 
	public GameObject[] powerUps;
	
	void Start () {
		//rb = GetComponent<Rigidbody2D> ();
		tiro = Resources.Load ("Prefab/shootFinalBoss") as GameObject;
	}
	
	
	void Update () {
		
		if (Random.Range (0, 2f) < 0.1f) {
			Instantiate(tiro,new Vector3(transform.position.x -1 ,transform.position.y,0),Quaternion.identity);
		}
		
		//rb.velocity = Vector3.left * speed;
	}
	
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.transform.tag.Equals ("shoot") || coll.transform.tag.Equals ("Player") || coll.transform.tag.Equals ("EnemyLimit")) {
			FinalBoss.FinalBossLife--;
			
			
			if (!coll.transform.tag.Equals ("EnemyLimit") && !coll.transform.tag.Equals ("Player")) {
				int randon = Random.Range (0, 30);

				if (randon == 5)
					Instantiate (powerUps [Random.Range (0, powerUps.Length)], transform.position, Quaternion.identity);
			}
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
