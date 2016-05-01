using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {
    public GameObject target;
    public Vector3 offset;

    void Start ()
    {
        offset = transform.position - target.transform.position;
    }

	void LateUpdate ()
    {
        transform.position = target.transform.position + offset;
	}
}
