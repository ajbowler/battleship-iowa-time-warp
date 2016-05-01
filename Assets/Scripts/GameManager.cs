using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Material[] shipMaterials;
    public PlayerShip playerShip;
    public Image healthBar;
    public float damageMultiplier;
    public static GameManager instance = null;

    private float reloadTimer;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        reloadTimer = 0;
        playerShip.health = 100;
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
                    AbstractEnemy enemy = hit.transform.gameObject.GetComponent<AbstractEnemy>();
                    if (enemy != null)
                    {
                        playerShip.FireOnEnemy(enemy);
                        reloadTimer = 300.0f;
                    }
                }
            }
        }
    }

    void UpdateHealth()
    {
        healthBar.fillAmount = playerShip.health / 100.0f;
        if (playerShip.health <= 0)
        {
            Application.LoadLevel(2);
        }
    }
}
