using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    float speed = 10.0f;
    public Transform colParticle;

    void Awake()
    {
        transform.Rotate(Vector3.down * 90);
    }

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
            Instantiate(colParticle, transform.position, transform.rotation);
            SoundManager.instance.PlaySoundFarExplosion1();
            SoundManager.instance.PlaySoundFarExplosion1();
        }
    }
}