using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    float speed = 50.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float toMove = speed * Time.deltaTime;
        transform.Translate(Vector3.right * toMove);

        if (transform.position.x > 200)
        {
            Destroy(gameObject);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Player")
        {
            Destroy(gameObject);
        }
        if (other.transform.tag=="Building")
        {
            Destroy(other.gameObject);
            GameManager.instance.AddScore(50);
        }
    }
}