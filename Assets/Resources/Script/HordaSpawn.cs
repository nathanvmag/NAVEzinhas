using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HordaSpawn : MonoBehaviour {
	
	public GameObject Construtor;
	public float rateSpawn;
	private float currentRateSpawn;
	public int maxEnemy;
	public GameObject[] prefab;
	public List<GameObject> Enemies;
	
	void Start () {
		
		for (int i = 0; i < maxEnemy; i++) {
			
			GameObject tempEnemy = Instantiate(prefab[Random.Range(0,prefab.Length)]) as GameObject;
			Enemies.Add(tempEnemy);
			tempEnemy.SetActive(false);
			//tempEnemy.transform.parent = Construtor.transform;
		}
		
	}
	
	
	void Update () {
		
		currentRateSpawn += Time.deltaTime;
	
		if (currentRateSpawn > rateSpawn) {
				currentRateSpawn = 0;
				Spawn ();
			}
	}
	
	private void Spawn(){

		
		float positionEnemyX = Construtor.transform.position.x ;
		float positionEnemyY = Construtor.transform.position.y;
		GameObject tempEnemy = null;
		
		for (int i = 0; i < maxEnemy; i++) {
				
			if(Enemies[i].activeSelf == false){
				tempEnemy = Enemies[i];
				break;
			}
		}
			
			if (tempEnemy != null) {
				tempEnemy.transform.position = new Vector3(positionEnemyX, positionEnemyY,0);
				tempEnemy.SetActive(true);
			}
	}
}
