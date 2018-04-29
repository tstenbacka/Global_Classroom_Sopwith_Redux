using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    static public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

   

	// Use this for initialization
	void Start () {
        offset = transform.position - Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        
        if(target!=null)
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
           
        }

    }
    
 }
