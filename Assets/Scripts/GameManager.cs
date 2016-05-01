using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Material[] shipMaterials;
    public PlayerShip playerShip;
    public Image healthBar;
    public float damageMultiplier;

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
                        FireOnEnemyShip(enemyShip);
                }
            }
        }
    }

    void UpdateHealth()
    {
        healthBar.fillAmount = playerShip.health / 100.0f;
    }

    void FireOnEnemyShip(EnemyShip enemyShip)
    {
        Vector3 distance = playerShip.transform.position - enemyShip.transform.position;
        float distanceMagnitude = Mathf.Abs(distance.magnitude);

        int damageDealt = CalculateDamage(distanceMagnitude);
        if (damageDealt > 0) Debug.Log(damageDealt);
        else Debug.Log("Miss!");

        enemyShip.health -= damageDealt;
        reloadTimer = 300;
        if (enemyShip.health < 0)
            Destroy(enemyShip.gameObject);
    }
    
    /// <summary>
    /// Calculates damage dealt based on distance between player and enemy. 
    /// The closer the distance, the higher the chance to hit and the higher the damage.
    /// </summary>
    int CalculateDamage(float distance)
    {
        float damage = playerShip.baseDamage * Random.value * damageMultiplier / distance;
        if (damage > playerShip.baseDamage) damage = playerShip.baseDamage;

        return Mathf.FloorToInt(damage);
    }
}
