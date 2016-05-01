using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour
{
    public float swingSpeed;
    public float swingAngle;
    public float health;
    public float baseDamage;
    public BillboardHit damageBillboard;
    public Texture[] hitMarkers;
    public float targetRadius;
    public GameObject target;

    private Rigidbody rb;
    private float startTime;
    private Quaternion start, end, baseRotation;
    private float reloadTimer;

    void Start()
    {
        start = Quaternion.AngleAxis(swingAngle, Vector3.right);
        end = Quaternion.AngleAxis(-swingAngle, Vector3.right);
        baseRotation = Quaternion.AngleAxis(270, new Vector3(1, 0, 0));
    }

    void Update()
    {
        startTime += Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0)) 
            * Quaternion.Lerp(start, end, (Mathf.Sin(startTime * swingSpeed + (swingAngle * Mathf.PI / 180)) + 1.0f) / 2) 
            * baseRotation;

        reloadTimer -= (Time.deltaTime * 100);
        if (reloadTimer < 0) reloadTimer = 0;
        if (reloadTimer <= 0)
        {
            GameObject ship = GameObject.Find("Player Ship");
            Vector3 diff = transform.position - ship.transform.position;
            if (diff.magnitude < targetRadius)
                FireWeapon();
        }
    }

    private void FireWeapon()
    {
        Debug.Log("Ship weapon fired");
        GameManager.instance.playerShip.health -= 25;
        reloadTimer = 500;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Vector3 markerPosition = transform.position;
        markerPosition.y += 4.0f;
        damageBillboard.tex = hitMarkers[damage];
        Instantiate(damageBillboard, markerPosition, Quaternion.identity);
    }
}
