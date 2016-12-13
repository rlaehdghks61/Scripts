using UnityEngine;
using System.Collections;

public class Scene1PlayerScripts : MonoBehaviour {

    public int exp;
    public int Maxexp;

	// Use this for initialization
	void Start ()
    {
        Maxexp = 4000;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //PlayerPrefs.DeleteAll();
        exp = PlayerPrefs.GetInt("NOWEXP");
	}
}
