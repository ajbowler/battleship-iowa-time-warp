using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthTestScript : MonoBehaviour {

    public static float health = 1.0f;
    public Image hbImage;

	// Use this for initialization
	void Start () {
        InvokeRepeating("reduceHealth", 1, 1);
	}

    private void reduceHealth()
    {
        //health -= .1f;
        hbImage.fillAmount = health;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
