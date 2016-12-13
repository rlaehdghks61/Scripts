using UnityEngine;
using System.Collections;

public class PoopGameManager : MonoBehaviour {

    public GameObject player;
    public GameObject GameOver;
    public GameObject enemyRespawn;
    public GameObject HomeBtn;

    public int foodnumManager;
    public int scene1FoodManager;
    public int FoodManager;
    public int scene1nowFoodnum;

    public bool PlayerDead;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        enemyRespawn = GameObject.Find("EnemyRespawn");
	}
	
	// Update is called once per frame
	void Update ()
    {
        scene1nowFoodnum = PlayerPrefs.GetInt("FOODSCENEGAMEMANAGER");
        foodnumManager = player.GetComponent<PlayerScripts>().foodNum; //푸드넘매니저는 player에 foodnum이다
	    if(player.GetComponent<PlayerScripts>().hp <= 0) // 만약 플레이어의 hp가 0보다 작거나같아질때
        {
            GameOver.SetActive(true); // 게임오버가 켜진다.
            player.SetActive(false); // 플레이어를 끈다.
            enemyRespawn.SetActive(false); // 적의 리스포너를 끈다.
            if(GameOver.transform.localPosition.y <= 435) // 만약 게임오버의 로컬포지션의 y가 435보다 같거나작아질때
            {
                FoodManager = foodnumManager + scene1FoodManager + scene1nowFoodnum;//푸드넘매니저를 신1푸드매니저에 더해준다.
                HomeBtn.SetActive(true); // 홈버튼을 활성화시킨다.
                PlayerPrefs.SetInt("FOODSCENEMANAGER", FoodManager); // 플팹을 셋팅해준다.
                Debug.Log(FoodManager);
            }
        }
	}

    public void Home()
    {
        Application.LoadLevel(1);
    }
}
