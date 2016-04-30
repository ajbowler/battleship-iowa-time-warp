using UnityEngine;
using System.Collections;

public class Enemy_Ship : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(1.0f, 0, 0) * speed;

    }
}
