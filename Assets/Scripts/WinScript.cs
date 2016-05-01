using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("Player Ship"))
        {
            Application.LoadLevel(3);
        }
    }
}
