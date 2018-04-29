using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Plane : NetworkBehaviour {

    public GameObject bulletPrefab;
    public GameObject missilePrefab;

    public Transform missileSpawn;
    public Transform bulletSpawn;


    public Text bombBox;
    
    public float speed = 0.0f;
    public float rotateSpeed = 10.0f;

    public const int initNumOfBomb = 10;

    public const float maxSpeed = 20.0f;
    public const float minSpeed = 20.0f;
    
    public bool isTakeOff = false;

    [SyncVar(hook = "OnChangeBomb")]
    public int numOfBomb;

    // Use this for initialization
    void Start () {
        if (isLocalPlayer)
        {
            numOfBomb = initNumOfBomb;
            CameraFollow.target = this.transform;
            //Camera.main.transform.position = this.transform.position + this.transform.forward * 30;
            //Camera.main.transform.LookAt(this.transform.position);
            //Camera.main.transform.parent = this.transform;
            //playerCamera.SetActive(true);
            //this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = true;
        }
        else
        {
            //playerCamera.SetActive(false);
            //this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (speed > 1)
        {
            isTakeOff = true;
        }

        if (h > 0)
            speed=speed+0.2f;
        if (h < 0)
            speed=speed-0.2f;


        if (speed < 0)
            speed = 0;

        if (speed < 5 && isTakeOff == true)
            speed = 5;

        if (speed > 20)
            speed = 20;

        if (transform.position.y > 50)
        {
            gameObject.GetComponent<Health>().TakeDamage(100);
        }

        float move = speed * Time.deltaTime;
        //h = h* speed * Time.deltaTime;
        v = v*  Time.deltaTime;

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.left * v* rotateSpeed);

        if (Input.GetButtonDown("Fire1"))
        {
            CmdFireMissile();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            CmdFireBullet();
        }

        if (Input.GetButtonDown("Jump"))
        {
            transform.Rotate(Vector3.forward * 180);
        }
        //transform.Translate(Vector3.up * v);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    [Command]
    void CmdFireBullet()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Bullet>().shooter = gameObject.GetComponent<Score>();
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50;
        NetworkServer.Spawn(bullet);

        Destroy(bullet, 5.0f);
    }

    [Command]
    void CmdFireMissile()
    {
        if(numOfBomb>0)
        {
            var missile = (GameObject)Instantiate(missilePrefab, missileSpawn.position, missileSpawn.rotation);
            missile.GetComponent<Missile>().shooter = gameObject.GetComponent<Score>();
            missile.GetComponent<Rigidbody>().velocity = missile.transform.right * 10;

            NetworkServer.Spawn(missile);
            numOfBomb--;

            Destroy(missile, 5.0f);
        }
    }


    public void Respawn()
    {
        isTakeOff = false;
        speed = 0.0f;
        numOfBomb = initNumOfBomb;
    }

    void OnChangeBomb(int numOfBomb)
    {
        bombBox.text = "Bomb : " + numOfBomb;
    }
}
