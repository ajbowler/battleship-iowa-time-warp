using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Material[] shipMaterials;
    //public PlayerShip playerShip;
    public float playerHealth;
    public Image healthBar;

    void Update()
    {
        UpdateHealth();
        UpdateEnemyShipDamage();
    }

    void UpdateEnemyShipDamage()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            EnemyShip ship = hit.transform.gameObject.GetComponent<EnemyShip>();
            if (ship != null)
                ship.GetComponentInChildren<MeshRenderer>().material = shipMaterials[2];
        }
    }

    void UpdateHealth()
    {
        healthBar.fillAmount = playerHealth;
    }
}
