﻿using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour {

    public float planeSpeed;
    public float targetRadius;
    public GameObject target;

    private float reloadTimer;

	// Use this for initialization
	void Start () {
        int xPos = Random.Range(-15, 16);
        transform.position = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(gameObject.transform.forward * planeSpeed);

        reloadTimer -= (Time.deltaTime * 1000);
        if (reloadTimer < 0) reloadTimer = 0;
        if(reloadTimer <= 0)
        {
            FireWeapon();
        }
	}

    private void FireWeapon()
    {
        Vector3 difference = transform.position - target.transform.position;
        Debug.Log(difference);
        if (difference.magnitude < targetRadius)
        {
            Debug.Log("FIRIN' WEAPON!");
            GameManager.instanace.playerShip.health -= 25;
            reloadTimer = 500;
        }
    }
}
