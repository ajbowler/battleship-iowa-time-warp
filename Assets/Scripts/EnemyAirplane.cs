using UnityEngine;
using System.Collections;

public class EnemyAirplane : AbstractEnemy {

    public float planeSpeed;
	
	protected override void Update()
    {
        transform.Translate(gameObject.transform.forward * planeSpeed);
        base.Update();
	}
}
