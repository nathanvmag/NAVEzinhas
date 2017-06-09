using UnityEngine;
using System.Collections;

public class FinalBoss : MonoBehaviour {

	public Transform BossPosition;
	static public int FinalBossLife;
	public GameObject Finalboss,BossArmUp,BossFingerUp,BossArmDown,BossFingerDown;

	void Start () {
		FinalBossLife = 100;
	}
	

	void Update () {

		Finalboss.transform.localPosition = Vector3.MoveTowards (Finalboss.transform.localPosition, BossPosition.localPosition, 2.5f * Time.deltaTime);

		if (FinalBossLife <= 67) {
			BossArmUp.SetActive(false);
			BossFingerUp.SetActive(false);
		}

		if (FinalBossLife <= 34) {
			BossArmDown.SetActive(false);
			BossFingerDown.SetActive(false);
		}

		if (FinalBossLife == 0) {
			Finalboss.SetActive(false);
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
