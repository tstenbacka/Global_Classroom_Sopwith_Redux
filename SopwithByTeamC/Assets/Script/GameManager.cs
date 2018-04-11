using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public UnityEngine.UI.Text scoreText;
    private int score = 0;

    void Awake()
    {

        if (!instance)
            instance = this;
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score;
    }

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
