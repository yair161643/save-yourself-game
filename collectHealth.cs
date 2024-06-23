using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class collectHealth : MonoBehaviour
{
    public GameObject parentThatWillSound;
    AudioSource healthPackAudio;
    public float rotationSpeed = 100f;


    // Start is called before the first frame update
    void Start()
    {
        healthPackAudio = parentThatWillSound.GetComponent<AudioSource>();

    }


    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            healthPackAudio.Play();
            PlayerMotion playerMotion = other.GetComponent<PlayerMotion>();

            if (playerMotion != null)
            {
                playerMotion.IncreaseHealth(20);
            }


            gameObject.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

    }
}
