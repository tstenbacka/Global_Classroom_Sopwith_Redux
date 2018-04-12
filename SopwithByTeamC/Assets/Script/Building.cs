using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public Transform colParticle;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Fire" || other.transform.tag =="Player")
        {
            Destroy(gameObject);
            SoundManager.instance.PlaySoundFarExplosion2();
        }
    }
    private void OnDestroy()
    {
        Instantiate(colParticle, transform.position, transform.rotation);
        GameManager.instance.AddScore(50);

    }
}
