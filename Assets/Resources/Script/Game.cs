using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private float currentTimeBoss,currentTimeFinalBoss,currentTimeWin;
	private float BossTime;
	private float FinalBossTime;
	private float RateWin;
	public GameObject Boss;
	public GameObject FinalBossX;
	public GameObject Enemies;



	void Start () {

		Boss.SetActive (false);
		FinalBossX.SetActive (false);
		BossTime = 30;
		FinalBossTime = 60;
		RateWin = 120;
	}
	

	void Update () {

		Debug.Log ("tempoFinalBoss " + currentTimeFinalBoss + " LifeFinalBoss " + FinalBoss.FinalBossLife + "FinalBossTime: " + FinalBossTime);
		currentTimeBoss += Time.deltaTime;
		currentTimeFinalBoss += Time.deltaTime;
		currentTimeWin += Time.deltaTime;

		if (currentTimeBoss > BossTime && BossTime < 50) {
			Boss.SetActive (true);
			Enemies.SetActive(false);
			currentTimeBoss = 0;
			BossTime += 20;
		}

		if (currentTimeFinalBoss > FinalBossTime && FinalBossTime < 80) {
			FinalBossX.SetActive (true);
			Enemies.SetActive(false);
			currentTimeFinalBoss = 0;
			FinalBossTime += 20;
		}

		if (FinalBossX.activeSelf == true) {
			Boss.SetActive(false);
		}

		if (Boss.activeSelf == false && FinalBossX.activeSelf == false) {
			Enemies.SetActive(true);
		}

		if (currentTimeWin > RateWin && Boss.activeSelf == false && FinalBossX.activeSelf == false) {
			Application.LoadLevel(3);
		}
	}


}
