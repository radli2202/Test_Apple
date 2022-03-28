using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTime : MonoBehaviour {

    public float scal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Time.timeScale = scal;
        }

    }
}
