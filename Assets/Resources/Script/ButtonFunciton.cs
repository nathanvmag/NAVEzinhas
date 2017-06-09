using UnityEngine;
using System.Collections;

public class ButtonFunciton : MonoBehaviour {

	public void ChangeToScene(int sceneToChangeTo){
		Application.LoadLevel(sceneToChangeTo);
	}

	public void Quit(){
		Application.Quit();
	}
}
