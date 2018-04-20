using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Plane : MonoBehaviour {

    float speed = 0.0f;
    public Transform colParticle;
    public GameObject Missile;
    public GameObject Bullet;

    public float maxSpeed = 20.0f;
    public float minSpeed = 20.0f;
    public int isTakeOff = 0;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (speed > 1)
        {
            isTakeOff = 1;
        }

        if (h > 0)
            speed++;
        if (h < 0)
            speed--;
        if (speed < 0)
            speed = 0;

        if (speed < 1 && isTakeOff!=0)
            speed = 1;

        if (speed > 20)
            speed = 20;


        float move= speed* Time.deltaTime;
        //h = h* speed * Time.deltaTime;
         //v = v*  Time.deltaTime;

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.left * v);
        //transform.Translate(Vector3.up * v);
        if (Input.GetButtonDown("Jump"))
        {
            transform.Rotate(Vector3.forward * 180);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (GameManager.instance.UseBomb() != 0)
            {
                Instantiate(Missile, transform.position, transform.rotation);
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {

            GameObject spPoint = GameObject.Find("spawnPoint");
            Instantiate(Bullet, spPoint.transform.position, transform.rotation);

            //Instantiate(Bullet, spPoint.transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag != "Fire")
        {
            //Destroy(gameObject);


            SoundManager.instance.PlaySoundNearExplosion1();
            Instantiate(colParticle, transform.position, transform.rotation);


            if (GameManager.instance.MinusLife() != 0)
            {
                transform.position = new Vector3((float)-19.9, (float)3.6, (float)7.5);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                speed = 0;
                isTakeOff = 0;
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        
        if (other.transform.tag != "Map" && other.transform.tag != "Fire")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        

    }
}
