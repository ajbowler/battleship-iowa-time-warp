using UnityEngine;
using System.Collections;

public class PlaneWaveTrigger : MonoBehaviour {

    public GameObject EnemyPlaneWave;

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
            Airplane[] enemyPlanes = EnemyPlaneWave.GetComponentsInChildren<Airplane>();
            foreach (Airplane plane in enemyPlanes)
            {
                plane.planeSpeed = -1;
            }
        }
    }
}
