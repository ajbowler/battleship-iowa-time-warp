using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals("Player Ship"))
            SceneManager.LoadScene("WinScreen");
    }
}
