using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject Plane;
    public UnityEngine.UI.Text scoreText;
    private int score = 0;
    private int life = 3;
    private int bomb = 10;


    void Awake()
    {

        if (!instance)
            instance = this;
        //Instantiate(Plane, new Vector3((float)-19.9, (float)3.6, (float)7.5), Quaternion.Euler(0, 90, 0));
    }
    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score + "\nBomb : "+ bomb+"\nLife : "+life;
    }

    public int UseBomb()
    {
        if (bomb <= 0)
        {
            return 0;
        }
        else
        { 
            bomb--;
            scoreText.text = "Score : " + score + "\nBomb : " + bomb + "\nLife : " + life;
            return 1;
        }   
    }

    public int MinusLife()
    {

        if (life <= 0)
        {
            return 0;
        }
        else
        {
            life--;
            bomb = 10;
            scoreText.text = "Score : " + score + "\nBomb : " + bomb + "\nLife : " + life;
            return 1;
        }
        
        //Instantiate(Plane, new Vector3((float)-19.9 , (float)3.6 , (float)7.5), Quaternion.Euler(0,90,0));
    }
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
