using UnityEngine;
using System.Collections;

public class PowerUP : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * 6 * Time.deltaTime);
	}
}
