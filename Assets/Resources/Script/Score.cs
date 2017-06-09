using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class Score : MonoBehaviour {

	public Text textoScore; 
	
	void Start () {
	
	}

	void Update () {
		textoScore.text = Enemy.score.ToString();
	}
}
