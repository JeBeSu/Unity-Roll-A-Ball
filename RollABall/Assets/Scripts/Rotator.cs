using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {


    public Vector3 asento;

	// Use this for initialization

		
	
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(asento * Time.deltaTime);
	}
}
