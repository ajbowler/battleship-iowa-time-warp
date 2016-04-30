using UnityEngine;
using System.Collections;

public class Airplane : MonoBehaviour {

    public float planeSpeed;

    public GameObject target;

	// Use this for initialization
	void Start () {
        Transform camTransform = Camera.main.transform;
        Vector3 camForward = camTransform.forward;
        //Debug.Log("Negative camera: "+ -camForward);
        //transform.forward = -camForward;//forward.Set(-camForward.x, -camForward.y, -camForward.z);
        //Debug.Log("Plane forward: "+ transform.forward);
        int xPos = Random.Range(-15, 16);
        transform.position = new Vector3(transform.position.x + xPos, transform.position.y + 12, transform.position.z + 100);
        //Vector3 cameraPos = Camera.main.transform.position;
        //transform.Rotate(new Vector3(0, 1, 0), camTransform.rotation.y);
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
        if (difference.magnitude < 50)
        {
            Debug.Log("FIRIN' WEAPON!");
        }
    }
}
