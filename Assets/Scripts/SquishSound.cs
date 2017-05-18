using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishSound : MonoBehaviour {

        public AudioClip Squish;    
                                  
                                 
        void Start()
        {
            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = Squish;
        }

        void OnCollisionEnter()  //Plays Sound Whenever collision detected
        {
            GetComponent<AudioSource>().Play();
        }
    }
