using UnityEngine;
using System.Collections;

public class Amigos : MonoBehaviour {

	public Transform posiUp,posiDown;
	public GameObject amigo1,amigo2;
	bool comecou,goUp,goDown,goUp1,goDown1; 

	void OnEnable()
	{
		comecou = true;
	}

	void Start () {
	
	}

	void Update () {
		if (comecou) {
			amigo1.transform.localPosition = Vector3.MoveTowards (amigo1.transform.localPosition, posiUp.localPosition, 0.5f * Time.deltaTime);
			amigo2.transform.localPosition = Vector3.MoveTowards (amigo2.transform.localPosition, posiDown.localPosition, 0.5f * Time.deltaTime);

		}

	}

	void OnDisable()
	{
			amigo1.transform.localPosition = new Vector3 (-7, -0.4f, 0);
			amigo2.transform.localPosition = new Vector3 (-7, -0.4f, 0);
	}
}
