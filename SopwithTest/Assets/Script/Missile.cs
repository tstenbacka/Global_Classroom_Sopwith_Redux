using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    
    public Score shooter;
    public Transform collisionParticle;

    void OnTriggerEnter(Collider collision)
    {
        

        var hit = collision.gameObject;
        
        if(hit.GetComponent<Score>()!=null && hit.GetComponent<Score>().Equals(shooter))
        {
            Debug.Log("It's me!");
        }
        else
        {

            var health = hit.GetComponent<Health>();
            Debug.Log(shooter);
            if (health != null)
            {
                Debug.Log(shooter);
                if (health.TakeDamage(40) == 1)
                {
                    shooter.AddScore(300);
                }
            }
            Destroy(gameObject);

        }
        
    }

    void OnDestroy()
    {
        Instantiate(collisionParticle, transform.position, transform.rotation);
        SoundManager.instance.PlaySoundFarExplosion1();
        SoundManager.instance.PlaySoundFarExplosion1();
    }
}
