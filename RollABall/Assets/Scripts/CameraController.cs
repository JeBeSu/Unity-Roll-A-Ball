using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform pelaaja;

    Vector3 offset;


	// Use this for initialization
	void Start () {
        offset = transform.position - pelaaja.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = pelaaja.position + offset;
	}
}
