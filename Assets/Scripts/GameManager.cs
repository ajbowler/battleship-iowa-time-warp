﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Material[] shipMaterials;
    public PlayerShip playerShip;
    public Image healthBar;

    private float reloadTimer;

    void Start()
    {
        reloadTimer = 0;
    }

    void Update()
    {
        reloadTimer -= (Time.deltaTime * 1000);
        if (reloadTimer < 0) reloadTimer = 0;

        UpdateHealth();

        if (Input.GetMouseButtonDown(0))
        {
            if (reloadTimer > 0) Debug.Log("Reloading!");
            else
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    EnemyShip enemyShip = hit.transform.gameObject.GetComponent<EnemyShip>();
                    if (enemyShip != null)
                    {
                        playerShip.FireOnEnemyShip(enemyShip);
                        reloadTimer = 300;
                    }
                }
            }
        }
    }

    void UpdateHealth()
    {
        healthBar.fillAmount = playerShip.health / 100.0f;
    }
}
