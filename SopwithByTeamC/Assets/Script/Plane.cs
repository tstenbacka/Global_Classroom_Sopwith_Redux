﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

    float speed = 20.0f;
    public Transform colParticle;
    public GameObject Missile;
    public GameObject Bullet;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;

        transform.Translate(Vector3.forward * h);
        transform.Translate(Vector3.up * v);

        if (Input.GetButtonDown("Fire1"))
        {
            Quaternion missileRotation;
            missileRotation = Quaternion.Euler(0, 0, 0);
            missileRotation.x = transform.rotation.x;
            missileRotation.z = transform.rotation.z;
            Instantiate(Missile,transform.position, missileRotation);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Quaternion missileRotation;
            missileRotation = Quaternion.Euler(0, 0, 0);
            missileRotation.x = transform.rotation.x;
            missileRotation.z = transform.rotation.z;
            GameObject spPoint = GameObject.Find("spawnPoint");
            Instantiate(Bullet, spPoint.transform.position, missileRotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag != "Fire")
        {
            Destroy(gameObject);
            SoundManager.instance.PlaySoundNearExplosion1();
        }
        
        if (other.transform.tag != "Map" && other.transform.tag != "Fire")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(colParticle, transform.position, transform.rotation);

    }
}
