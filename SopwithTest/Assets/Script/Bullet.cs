using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public Score shooter;
    public Transform collisionParticle;

    void OnTriggerEnter(Collider collision)
    {
        var hit = collision.gameObject;
        if (hit.GetComponent<Score>() != null && hit.GetComponent<Score>().Equals(shooter))
        {
            Debug.Log("It's me!");
        }
        else
        {

            var health = hit.GetComponent<Health>();
            Debug.Log(shooter);
            if (health != null)
            {
                if (health.TakeDamage(10) == 1)
                {

                    Debug.Log(shooter);
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
    }
}
