using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public Transform collisionParticle;
    public int score = 10;
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider collision)
    {
        var hit = collision.gameObject;

        if (hit.GetComponent<Bullet>())
        {
            if (hit.GetComponent<Bullet>().shooter)
            {
                hit.GetComponent<Bullet>().shooter.AddScore(score);
            }
            
        }

        if (hit.GetComponent<Missile>())
        {
            if(hit.GetComponent<Missile>().shooter)
            {
                hit.GetComponent<Missile>().shooter.AddScore(score);
            }
            
        }

        if (hit.GetComponent<Score>())
        {
            hit.GetComponent<Score>().AddScore(score);
        }

        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Instantiate(collisionParticle, transform.position, transform.rotation);
        SoundManager.instance.PlaySoundFarExplosion2();
    }
}
