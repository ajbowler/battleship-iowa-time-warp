using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

    public float speed;

    private Vector3 moveTo;

    void Start()
    {
        moveTo = transform.position;
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveTo = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveTo = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position, moveTo, speed * Time.deltaTime);
	}
}
