using UnityEngine;
using System.Collections;

public class Scene1Manager : MonoBehaviour {

    public GameObject stuffbar;
    public GameObject cleanbar;
    public GameObject happybar;
    public GameObject gameover;
    public GameObject foodNumLabel;
    public GameObject happypicture;
    public GameObject normalpicture;
    public GameObject dirtypicture;
    public GameObject Player;

    public float stuffNum;
    public float cleanNum;
    public float happyNum;


    public int foodexp;
    public int showerexp;
    public int maxexp;
    public int mainexp;

    public int PoopGameManagerFood;
    public int allfoodnum;
    public int foodNumber;
    public int nowFoodnum; // 현재 푸드의 갯수

    public bool stuff;
    public bool clean;
    public bool happy;

	// Use this for initialization
	void Start ()
    {
        stuffNum = 100;
        cleanNum = 100;
        happyNum = 100;

        stuffbar = GameObject.Find("stuffgaugeback");
        happybar = GameObject.Find("cleangaugeback");
        cleanbar = GameObject.Find("Happygaugeback");
    }
	
	// Update is called once per frame
	void Update ()
    {
        mainexp = foodexp + showerexp;
        PlayerPrefs.GetInt("FOODEXP");
        PlayerPrefs.GetInt("SHOWER");

        PoopGameManagerFood = PlayerPrefs.GetInt("FOODSCENEMANAGER");
        allfoodnum = PoopGameManagerFood;
        foodNumLabel.GetComponent<UILabel>().text = allfoodnum.ToString();
        PlayerPrefs.SetInt("FOODSCENEGAMEMANAGER", allfoodnum);
        stuffNum -= Time.deltaTime * 0.025f;
        cleanNum -= Time.deltaTime * 0.010f;
        happyNum -= Time.deltaTime * 0.010f;
       
        if(happyNum >= 80)
        {
            happypicture.SetActive(true);
            normalpicture.SetActive(false);
            dirtypicture.SetActive(false);
        }
        else
        {
            normalpicture.SetActive(true);
            happypicture.SetActive(false);
            dirtypicture.SetActive(false);
        }
        if (happyNum >= 80 && cleanNum <= 50)
        {
            happypicture.SetActive(false);
            normalpicture.SetActive(false);
            dirtypicture.SetActive(true);
        }
        if(cleanNum > 50 && happyNum < 80)
        {
            dirtypicture.SetActive(false);
            happypicture.SetActive(false);
            normalpicture.SetActive(true);
        }
        if(cleanNum <= 50)
        {
            normalpicture.SetActive(false);
            happypicture.SetActive(false);
            dirtypicture.SetActive(true);
        }

        if(stuffNum >= 100)
        {
            stuffNum = 100;
        }
        if(cleanNum >= 100)
        {
            cleanNum = 100;
        }
        if(happyNum >= 100)
        {
            happyNum = 100;
        }


        if (stuffNum <= 0)
        {
            stuffNum = 0;
            stuff = true;
        }
        else
        {
            stuff = false;
        }

        if (cleanNum <= 0)
        {
            cleanNum = 0;
            clean = true;
        }
        else
        {
            clean = false;
        }

        if (happyNum <= 0)
        {
            happyNum = 0;
            happy = true;
        }
        else
        {
            happy = false;
        }

        if(stuff == true && happy == true || stuff == true && clean == true || happy == true && clean == true)
        {
            Invoke("GameOver", 30f);
        }


        float stuffMax = stuffNum * 0.01f;
        float cleanMax = cleanNum * 0.01f;
        float happyMax = happyNum * 0.01f;

        stuffbar.GetComponent<UIProgressBar>().value = stuffMax;
        cleanbar.GetComponent<UIProgressBar>().value = cleanMax;
        happybar.GetComponent<UIProgressBar>().value = happyMax;
    }

    void GameOver()
    {
        gameover.SetActive(true);
    }

    public void Eatrice()
    {
        stuffNum += 20;
        foodexp = 50 + foodexp;
        PlayerPrefs.SetInt("FOODEXP", foodexp);
        Debug.Log(foodexp);
    }

    public void shower()
    {
        cleanNum += 20;
        showerexp = 30 + showerexp;
        PlayerPrefs.SetInt("SHOWER", foodexp);
    }

    public void minigame()
    {
        Application.LoadLevel(3);
    }
}
