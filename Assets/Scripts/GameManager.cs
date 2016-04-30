using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public Material[] shipMaterials;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            Enemy_Ship ship = hit.transform.gameObject.GetComponent<Enemy_Ship>();
            if (ship != null)
                ship.GetComponentInChildren<MeshRenderer>().material = shipMaterials[2];
        }
    }

}
