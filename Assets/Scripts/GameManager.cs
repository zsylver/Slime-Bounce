using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public Transform player;    //Object to track is player
    float playerHeightY;        // Height at which camera will adjust to

    public Transform regular;   //Store platform prefabs
    public Transform jump;
    public Transform LeftRight;
    public Transform UpDown;

    private int platNumber; // used to assign prefabs to a number 1-4

    private float platCheck;    //checks if player height is near and spawn platform
    private float spawnPlatformTo;  //prev location platforms were spawned

	// Use this for initialization
	void Start () {
        //finds our player game object using the player tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
        playerHeightY = player.position.y;  //Tracks current player's y axis

        if (playerHeightY > platCheck)  //if player height y is greater than 0 then perform PlatformManager method
        {
            PlatformManager();  //Calls PlatformManager method
        }
        float currentCameraHeight = transform.position.y;   //Tracks our current camera y axis

        float newHeightOfCamera = Mathf.Lerp(currentCameraHeight, playerHeightY, Time.deltaTime * 10);  //Adjustment of new height

        if(playerHeightY > currentCameraHeight) //Adjustment = move camera up if player height is higher than current camera height
        {
            // new camera position = it's current x , new height for camera , current z
            transform.position = new Vector3(transform.position.x, newHeightOfCamera, transform.position.z);

        }
        else
        {   
            
            if(playerHeightY < (currentCameraHeight - 5.5f))
            {
                OnGUI2D.OG2D.CheckHighScore();
                SceneManager.LoadScene("Scene1");
            }
        }
        //Takes our player's current y and assigns it if higher than current score to = our score
        if (playerHeightY > OnGUI2D.score)
        {
            // Assign score var to int based of our playerHeightY
            OnGUI2D.score = (int)playerHeightY;
        }
	}


    void PlatformManager()
    {
        //Assign the platcheck to our player's current y value + 15
        platCheck = player.position.y + 15;

        //Sends a float value at start
        PlatformSpawner(platCheck + 15);
    }


    void PlatformSpawner(float floatValue)
    {
        //y starts at 0, spawnPlatforms spawns at 0, this is used as a loop
        float y = spawnPlatformTo;

        
        while ( y <= floatValue)
        { 
            float x = Random.Range(-2.7f, 2.7f);
            

            platNumber = Random.Range(1, 5);

            Vector2 posXY = new Vector2(x, y);

            // use the platnumber to randomly pick to spawn a specific platform
            if (platNumber == 1)
                {
                Instantiate(regular, posXY, Quaternion.identity);
                }
            if (platNumber == 2)
                {
                Instantiate(jump, posXY, Quaternion.identity);
                }
            if (platNumber == 3)
            {
                Instantiate(LeftRight, posXY, Quaternion.identity);
            }
            if (platNumber == 4)
            {
                Instantiate(UpDown, posXY, Quaternion.identity);
            }
            
            y += Random.Range(0.5f, 2f);
            Debug.Log("Spawned Platform");
        }

        spawnPlatformTo = floatValue;
    }
}
