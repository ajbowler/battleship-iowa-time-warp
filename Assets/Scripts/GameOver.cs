﻿using UnityEngine;

public class GameOver : MonoBehaviour
{
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	}
}
