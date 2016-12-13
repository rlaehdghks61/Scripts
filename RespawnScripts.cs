﻿using UnityEngine;
using System.Collections;

public class EnemyRespawn : MonoBehaviour {

    public GameObject Enemy;
    public GameObject food;

    public float coolTime;
    public float genTime;
    public float foodcoolTime;
    public float foodgenTime;
    public float Randomx;

	// Use this for initialization
	void Start ()
    {
        genTime = 2f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        genTime -= Time.deltaTime;
	    if(genTime < 0)
        {
            Randomx = Random.Range(-2.56f, 2.56f);
            Instantiate(Enemy, new Vector3(Randomx, 15f, 0), transform.rotation);
            Instantiate(food, new Vector3(Randomx,15f,0),transform.rotation);
            coolTime = Random.Range(0.1f, 0.8f);
            genTime = coolTime;
        }
	}
}
