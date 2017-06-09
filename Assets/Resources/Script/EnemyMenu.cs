using UnityEngine;
using System.Collections;

public class EnemyMenu : MonoBehaviour {

	private int velocidade1,velocidade2,velocidade3;
	public Transform posiUp,posiDown;
	public GameObject enemy1,enemy2, spaceship;
	public bool work;

	void Start(){
		work = true;
	}

	void Update () {
		velocidade1 = 100;
		velocidade2 = 1;

		enemy1.transform.Rotate (Vector3.forward * Time.deltaTime * velocidade1);
		enemy2.transform.Rotate (Vector3.forward * Time.deltaTime * velocidade1);
		enemy1.transform.Translate (Vector3.up * Time.deltaTime * velocidade2);
		enemy2.transform.Translate (Vector3.down * Time.deltaTime * velocidade2);


		if (work) {
			spaceship.transform.localPosition = Vector3.MoveTowards (spaceship.transform.localPosition, posiUp.localPosition, 2.5f * Time.deltaTime);
		}

		if(spaceship.transform.position.y >= 3.65)
		{
			work = false;
		}

		if (!work) {
			spaceship.transform.localPosition = Vector3.MoveTowards (spaceship.transform.localPosition, posiDown.localPosition, 2.5f * Time.deltaTime);
		}

		if(spaceship.transform.position.y <= -3.72)
		{
			work = true;
		}

		/*if(spaceship.transform.position.y >= 3.65)
		{
			work = false;
		}*/

	}
}
