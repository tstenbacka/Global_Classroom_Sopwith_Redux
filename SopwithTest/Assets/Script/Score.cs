using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Score : NetworkBehaviour {


    public Text scoreBox;

    [SyncVar(hook = "OnChangeScore")]
    public int score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int amount)
    {
        if (!isServer)
            return;
        score += amount;
    }

    void OnChangeScore(int score)
    {
        //show score change
        scoreBox.text = "Score : " + score;
    }
}
