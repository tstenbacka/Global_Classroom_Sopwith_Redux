using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public GameObject myPlane;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cameraPosition = transform.position;


        cameraPosition.x = myPlane.transform.position.x;
        if (cameraPosition.x < 0)
        {
            cameraPosition.x = 0;
        }
        if (cameraPosition.x > 98)
        {
            cameraPosition.x = 98;
        }
        
        transform.position = cameraPosition;
        

	}
}
