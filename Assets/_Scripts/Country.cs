using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour {

    public float A;
    [Range(50,200)]
    public float h;
    public float I;
    [Range(1,4)]
    public int SRD = 1;

    private const float ipc = 0.001f;
    private float IO = 0f;
    private float SP0 = 20f;
    private float MKT0 = 15f;
    private float MAKRET0 = 15f;
    private float L0 = 10f;
    private float KH0 = 10f;
    private float NS0 = 20f;
    private float ST0 = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
