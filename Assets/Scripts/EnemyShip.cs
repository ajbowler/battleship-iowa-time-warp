using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed;
    public float swingSpeed;
    public float swingAngle;
    private float startTime;
    private Quaternion start, end;

    void Start()
    {
        start = Quaternion.AngleAxis(swingAngle, Vector3.right);
        end = Quaternion.AngleAxis(-swingAngle, Vector3.right);
    }

    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -1) * moveSpeed;
    }

    void Update()
    {
        startTime += Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0)) * Quaternion.Lerp(start, end, (Mathf.Sin(startTime * swingSpeed + (swingAngle * Mathf.PI / 180)) + 1.0f) / 2) * Quaternion.AngleAxis(270, new Vector3(1, 0, 0));
    }
}
