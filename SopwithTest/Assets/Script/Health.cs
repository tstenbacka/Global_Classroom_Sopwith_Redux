using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 100;
    [SyncVar(hook ="OnChangeHealth")]
    public int currentHealth = maxHealth;
    public RectTransform healthBar;
    public Text lifeBox;
    public Transform collisionParticle;

    public bool DestroyOnDeath=false;

    public const int initLife = 3;

    [SyncVar(hook = "OnChangeLife")]
    public int life;

    private NetworkStartPosition[] spawnPoints;


    private void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
            life = initLife;
        }
    }

    public int TakeDamage(int amount)
    {
        Debug.Log("Call TakeDamage");
        if (!isServer)
        {
            return -1;
        }
            


        currentHealth -= amount;
        if (currentHealth <= 0)
        {

            if (DestroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                currentHealth = maxHealth;
                life--;
                
                gameObject.GetComponent<Plane>().Respawn();
                if (life <= 0)
                {
                    DestroyOnDeath = true;
                }
                RpcRespawn();
            }
            GetComponent<Score>().AddScore(-100);
            Instantiate(collisionParticle, transform.position, transform.rotation);
            SoundManager.instance.PlaySoundNearExplosion1();
            return 1;
        }
        else
        {
            return 0;
        }
        
    }
    

    void OnChangeHealth(int currentHealth)
    {
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;
            
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
                
            }

            gameObject.GetComponent<Plane>().Respawn();
            transform.position = spawnPoint;
            transform.rotation = Quaternion.Euler(0,0,0);

            
        }

    }
    void OnChangeLife(int life)
    {
        lifeBox.text = "Life : " + life;
    }
}
