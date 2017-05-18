using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUI2D : MonoBehaviour {

    public static OnGUI2D OG2D;
    public static int score;

    int highScore;
   
	// Use this for initialization
	void Start () {

        OG2D = this;
        score = 0;
        highScore = PlayerPrefs.GetInt("Highscore1", 0);

	}
	
    void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 200, 20), "Top Height: " + highScore + "m");
        GUI.Label(new Rect(10, 10, 200, 20), "Height Travelled: " + (score*10) + "m");
    }

    public void CheckHighScore()
    {
        if((score*10) > highScore)
        {

            Debug.Log("Saving Score");
            PlayerPrefs.SetInt("Highscore1", (score*10));

        }
    }
}
