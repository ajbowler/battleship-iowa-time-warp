using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

    public float forwardSpeed;
    public float lateralSpeed;
    public float turnSpeed;
    public float baseDamage;
    public float health;
    public float damageMultiplier;

    public BillboardHit damageBillboard;
    public Texture[] hitMarkers;

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
        moveTo.y = -1.66f; // water level

        transform.position = Vector3.Lerp(transform.position, moveTo, Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotateTo, Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") health = 0;
    }

    public void FireOnEnemy(AbstractEnemy enemy)
    {
        GetComponents<AudioSource>()[0].Play();
        Vector3 distance = transform.position - enemy.transform.position;
        float distanceMagnitude = Mathf.Abs(distance.magnitude);
        int damageDealt = CalculateDamage(distanceMagnitude);
        enemy.TakeDamage(damageDealt);
    }

    /// <summary>
    /// Calculates damage dealt based on distance between player and enemy. 
    /// The closer the distance, the higher the chance to hit and the higher the damage.
    /// </summary>
    int CalculateDamage(float distance)
    {
        float damage = baseDamage * Random.value * damageMultiplier / distance;
        if (damage > baseDamage) damage = baseDamage;
        return Mathf.FloorToInt(damage);
    }
}
