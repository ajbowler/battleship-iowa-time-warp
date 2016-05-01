using UnityEngine;
using System.Collections;

public class PlaneWaveTrigger : MonoBehaviour {

    public GameObject EnemyPlaneWave;

    public float newPlaneSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("Player Ship"))
        {
            EnemyAirplane[] enemyPlanes = EnemyPlaneWave.GetComponentsInChildren<EnemyAirplane>();
            foreach (EnemyAirplane plane in enemyPlanes)
            {
                plane.planeSpeed = newPlaneSpeed;
            }
        }
    }
}
