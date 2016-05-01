using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour {

    public float planeSpeed;
    public float targetRadius;
    public GameObject target;

	// Use this for initialization
	void Start () {
        int xPos = Random.Range(-15, 16);
        transform.position = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(gameObject.transform.forward * planeSpeed);
        FireWeapon();
	}

    private void FireWeapon()
    {
        Vector3 difference = transform.position - target.transform.position;
        Debug.Log(difference);
        if (difference.magnitude < targetRadius)
        {
            Debug.Log("FIRIN' WEAPON!");
        }
    }
}
