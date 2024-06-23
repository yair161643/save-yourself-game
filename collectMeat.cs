using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class collectMeat : MonoBehaviour
{

    public GameObject parentThatWillSound;
    AudioSource meatPickAudio;
    public Text meatCollectedSum;
    public static int numberOfMeatCollected = 13;
    public float rotationSpeed = 100f;



    // Start is called before the first frame update
    void Start()
    {
        meatPickAudio = parentThatWillSound.GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            meatPickAudio.Play();
            numberOfMeatCollected++;
            meatCollectedSum.text = "" + numberOfMeatCollected;
            gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its up axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        meatCollectedSum.text = "" + numberOfMeatCollected;


    }

    public static void ChangeAmount(int number)
    {
        numberOfMeatCollected = number;
        
    }
}
