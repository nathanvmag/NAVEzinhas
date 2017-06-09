using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnShoot : MonoBehaviour {

	public GameObject Construtor;
	public float rateSpawn;
	private float currentRateSpawn;
	public int maxShoot;
	public GameObject prefab;
	public List<GameObject> shoot;
	/*int controle; */

	void Start () {

		for (int i = 0; i < maxShoot; i++) {

			GameObject tempShoot = Instantiate(prefab) as GameObject;
			shoot.Add(tempShoot);
			tempShoot.SetActive(false);
			//tempShoot.transform.parent = Construtor.transform;
		}


	}
	

	void Update () {
	
		currentRateSpawn += Time.deltaTime;

		if (Input.GetKey (KeyCode.Space)) {
			if (currentRateSpawn > rateSpawn) {
				currentRateSpawn = 0;
				Spawn ();
			}
		}
	}

	private void Spawn(){

		float positionShootX = Construtor.transform.position.x;
		float positionShootY = Construtor.transform.position.y;
		GameObject tempShoot = null;

		for (int i = 0; i < maxShoot; i++) {

			if (shoot [i].activeSelf == false) {
				tempShoot = shoot [i];
				/*controle = i;*/
				break;
			}
		}

		if (tempShoot != null) {
			tempShoot.transform.position = new Vector3 (positionShootX, positionShootY, transform.position.z);
			tempShoot.SetActive (true);

				if (PlayerMove.ShootPW)
				{
					GameObject copy1 = tempShoot;
					Instantiate(copy1, new Vector3 (positionShootX, positionShootY, transform.position.z),Quaternion.Euler(0,0,30));
					Instantiate(copy1, new Vector3 (positionShootX, positionShootY, transform.position.z),Quaternion.Euler(0,0,-30));

				}

			}			

	}
}
