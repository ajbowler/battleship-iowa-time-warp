using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour
{
    public float swingSpeed;
    public float swingAngle;
    public float health;
    public float baseDamage;

    private Rigidbody rb;
    private float startTime;
    private Quaternion start, end, baseRotation;

    void Start()
    {
        start = Quaternion.AngleAxis(swingAngle, Vector3.right);
        end = Quaternion.AngleAxis(-swingAngle, Vector3.right);
        baseRotation = Quaternion.AngleAxis(270, new Vector3(1, 0, 0));
    }

    void Update()
    {
        startTime += Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0)) 
            * Quaternion.Lerp(start, end, (Mathf.Sin(startTime * swingSpeed + (swingAngle * Mathf.PI / 180)) + 1.0f) / 2) 
            * baseRotation;
    }
}
