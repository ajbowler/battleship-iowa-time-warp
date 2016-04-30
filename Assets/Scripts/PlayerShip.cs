using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

    public float forwardSpeed;
    public float lateralSpeed;
    public float turnSpeed;

    private Vector3 moveTo;
    private Quaternion rotateTo;

    void Start()
    {
        moveTo = transform.position;
        rotateTo = transform.rotation;
    }
	
	void Update ()
    {
        moveTo = transform.position;
        rotateTo = Quaternion.FromToRotation(Vector3.forward, Vector3.forward);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveTo.x -= lateralSpeed;
            rotateTo = Quaternion.FromToRotation(Vector3.forward, new Vector3(-0.4f,0f,1f));
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveTo.x += lateralSpeed;
            rotateTo = Quaternion.FromToRotation(Vector3.forward, new Vector3(0.4f,0f,1f));
        }

        moveTo.z += forwardSpeed;

        transform.position = Vector3.Lerp(transform.position, moveTo, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotateTo, Time.deltaTime);
	}
}
