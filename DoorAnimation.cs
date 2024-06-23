using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    Animator doorAnimation;
    AudioSource doorSound;
    // Start is called before the first frame update
    void Start()
    {
        doorAnimation = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();



    }

    private void OnTriggerEnter(Collider other)
    {
        doorAnimation.SetBool("openDoor", true);
        doorSound.PlayDelayed(0.3f);
    }
    private void OnTriggerExit(Collider other)
    {
        doorAnimation.SetBool("openDoor", false);
        doorSound.PlayDelayed(0.3f);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
