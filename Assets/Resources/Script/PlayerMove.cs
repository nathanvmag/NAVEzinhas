using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	public int velocidade;
	Rigidbody2D rb;
	public static bool SpeedUpPW,ShootPW,ShieldPW,FriendsPW; 
	float TimeSpeedUpPW,TimeShootPW,TimeFriendsPW;
	public GameObject shield; 
	public GameObject[] Friends;

	void Start(){

		rb = GetComponent<Rigidbody2D> ();
		TimeSpeedUpPW = 20; 
		TimeShootPW = 13;

	}
	
	void Update () {

		if (FriendsPW){
			TimeFriendsPW -= Time.deltaTime;
			if (TimeFriendsPW<0) FriendsPW = false; 

			Friends [0].SetActive (true);			
			Friends [1].SetActive (true);
		}

		else {
			Friends[0].SetActive(false);			
			Friends[1].SetActive(false);
			TimeFriendsPW = 10;
		}

		if (ShootPW) {
			TimeShootPW -= Time.deltaTime;

			if (TimeShootPW<0){
				ShootPW= false ;
				TimeShootPW= 13; 
			}
		}

		if (SpeedUpPW) {
			TimeSpeedUpPW -= Time.deltaTime;

			if (TimeSpeedUpPW > 0){
				velocidade = 10; 
			} 

			else {
				velocidade = 5;
				SpeedUpPW = false; 
				TimeSpeedUpPW = 20;
			}
		}

		if (ShieldPW) {
			shield.SetActive (true); 			
		}

		else {			
			shield.SetActive (false);
		}
	
	
		if (Input.GetKey(KeyCode.RightArrow)) {
			rb.velocity= new Vector2(velocidade,rb.velocity.y);
		}

		if (Input.GetKeyUp(KeyCode.RightArrow)) {
			rb.velocity= new Vector2(0,rb.velocity.y);
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			rb.velocity = new Vector2(-velocidade,rb.velocity.y);
		}

		if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			rb.velocity= new Vector2(0,rb.velocity.y);
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			rb.velocity = new Vector2(rb.velocity.x, velocidade);
		}

		if (Input.GetKeyUp(KeyCode.UpArrow)) {
			rb.velocity= new Vector2(rb.velocity.x,0);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			rb.velocity = new Vector2(rb.velocity.x, -velocidade);
		}

		if (Input.GetKeyUp(KeyCode.DownArrow)) {
			rb.velocity= new Vector2(rb.velocity.x,0);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("EnemyLimit") || coll.gameObject.tag.Equals ("shoot") || coll.gameObject.tag.Equals ("Limit")) {
		} 
		else if (ShieldPW) {
			ShieldPW = false; 
		} 
		else {
			Destroy(gameObject); 
			Application.LoadLevel(4);
		}

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag.Equals ("SpeedUpPW")) {
			Destroy(coll.gameObject);
			TimeSpeedUpPW = 20;
			SpeedUpPW = true ;
			Enemy.score +=20;
		}
		if (coll.gameObject.tag.Equals ("ShootPW")) {
			Destroy(coll.gameObject);
			TimeShootPW=13;
			ShootPW = true ;
			Enemy.score +=20;
		}
		if (coll.gameObject.tag.Equals ("ShildPW")) {
			Destroy(coll.gameObject);
			ShieldPW = true ;
			Enemy.score +=20;
		}
		if (coll.gameObject.tag.Equals ("FriendsPW")) {
			Destroy(coll.gameObject);
			TimeFriendsPW= 10; 
			FriendsPW = true ;
			Enemy.score += 20;
		}

	}
}
