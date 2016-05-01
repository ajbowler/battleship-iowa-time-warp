﻿using UnityEngine;
using System.Collections;

public abstract class AbstractEnemy : MonoBehaviour
{
    public float health;
    public float baseDamage;
    public float reloadTime;

    public float targetRadius;

    public BillboardHit damageBillboard;
    public Texture[] hitMarkers;

    protected string targetName;
    protected Rigidbody body;
    protected float reloadTimer;

    protected AudioSource deathNoise;

    protected virtual void Start() {
        targetName = "Player Ship";
        reloadTimer = 0;
        deathNoise = GetComponents<AudioSource>()[0];
    }

    protected virtual void Update()
    {
        reloadTimer -= (Time.deltaTime);
        if (reloadTimer < 0) reloadTimer = 0;
        if (reloadTimer <= 0)
        {
            GameObject target = GameObject.Find(targetName);
            Vector3 diff = transform.position - target.transform.position;
            if (diff.magnitude < targetRadius)
                FireWeapon();
        }
    }

    private void FireWeapon()
    {
        GameManager.instance.playerShip.health -= baseDamage;
        reloadTimer = reloadTime;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Vector3 markerPosition = transform.position;
        markerPosition.y += 4.0f;
        damageBillboard.tex = hitMarkers[damage];
        Instantiate(damageBillboard, markerPosition, Quaternion.identity);
        if (health < 0)
        {
            print("DIE!!!");
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.useGravity = true;
        print("Gravity");
        deathNoise.Play();
        while (transform.position.y > -50f) {
            yield return null;
        }
        print("Destroy");
        Destroy(gameObject);
    }
}