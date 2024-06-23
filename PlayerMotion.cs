using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMotion : MonoBehaviour
{
    // Initialization of variables
    public float cameraRotationSpeed = 1f;
    public float movementspeed = 0;
    public float vertical = 0;
    public float horizontal = 0;
    private AudioSource footStep;
    public Text healthText;
    public GameObject camera;
    CharacterController cController;
    public GameObject gunInHand;
    public GameObject gunInHandSecond;
    private GameObject[] enemies;
    public Text instructionText;
    public GameObject mainCamera;
    public GameObject introCamera;
    public GameObject mutantsWaveOne;
    public GameObject mutantsWaveTwo;
    public GameObject mutantsWaveThree;
    public GameObject mutantsWaveFour;
    public GameObject mutantsWaveFive;
    public GameObject mutantsWaveSix;
    public GameObject mutantsWaveSeven;
    public GameObject mutantsWaveEight;
    public GameObject mutantsWaveNine;
    public GameObject mutantsWaveTen;
    public Text instructionTextCave;
    private bool waveOneIsDown;
    private bool waveTwoIsDown;
    private bool waveThreeIsDown;
    private bool waveFourIsDown;
    private bool waveFiveIsDown;
    private bool waveSixIsDown;
    private bool waveSevenIsDown;
    private bool waveEightIsDown;
    private bool waveNineIsDown;
    private bool waveTenIsDown;
    private DrawerMotion checkRockDoor;
    private int waveCount = 1;
    public Text waveCountTxt;
    public GameObject uiShopItems;







    // Health variable
    public int health = 100;

    void Start()
    {
        waveOneIsDown = false;
        healthText.text = ("HP: " + health);
        cController = GetComponent<CharacterController>();
        footStep = GetComponent<AudioSource>();
        checkRockDoor = GameObject.FindObjectOfType<DrawerMotion>();

    }

    void Update()
    {

        if (!waveOneIsDown && MutantsWaveOneIsCleared())
        {
            waveCount++;
            waveCountTxt.text = "Wave: " + waveCount;
            Debug.Log("Wave 1 down");
            waveOneIsDown = true;
            // You can add additional logic here for what happens when the wave is cleared
        }

        if (!waveTwoIsDown && MutantsWaveTwoIsCleared())
        {
            waveCount++;
            waveCountTxt.text = "Wave: " + waveCount;
            Debug.Log("Wave 1 down");
            waveTwoIsDown = true;
            // You can add additional logic here for what happens when the wave is cleared
        }

        if (!waveThreeIsDown && MutantsWaveThreeIsCleared())
        {
            waveCount++;
            waveCountTxt.text = "Wave: " + waveCount;
            Debug.Log("Wave 1 down");
            waveThreeIsDown = true;
            // You can add additional logic here for what happens when the wave is cleared
        }
        if (!waveFourIsDown && MutantsWaveFourIsCleared())
        {
            waveCount++;
            waveCountTxt.text = "Wave: " + waveCount;
            Debug.Log("Wave 1 down");
            waveFourIsDown = true;
            // You can add additional logic here for what happens when the wave is cleared
        }
        if (!waveFiveIsDown && MutantsWaveFiveIsCleared())
        {
            waveCount++;
            waveCountTxt.text = "Wave: " + waveCount;
            Debug.Log("Wave 1 down");
            waveFiveIsDown = true;
            // You can add additional logic here for what happens when the wave is cleared
        }
        if (!waveSixIsDown && MutantsWaveSixIsCleared())
        {
            waveCount++;
            waveCountTxt.text = "Wave: " + waveCount;
            Debug.Log("Wave 1 down");
            waveSixIsDown = true;
            // You can add additional logic here for what happens when the wave is cleared
        }
        if (!waveSevenIsDown && MutantsWaveSevenIsCleared())
        {
            waveCount++;
            waveCountTxt.text = "Wave: " + waveCount;
            Debug.Log("Wave 1 down");
            waveSevenIsDown = true;
            // You can add additional logic here for what happens when the wave is cleared
        }
        if (!waveEightIsDown && MutantsWaveEightIsCleared())
        {
            waveCount++;
            waveCountTxt.text = "Wave: " + waveCount;
            Debug.Log("Wave 1 down");
            waveEightIsDown = true;
            // You can add additional logic here for what happens when the wave is cleared
        }
        if (!waveNineIsDown && MutantsWaveNineIsCleared())
        {
            waveCount++;
            waveCountTxt.text = "Wave: " + waveCount;
            Debug.Log("Wave 1 down");
            waveNineIsDown = true;
            // You can add additional logic here for what happens when the wave is cleared
        }
        if (!waveTenIsDown && MutantsWaveTenIsCleared())
        {
            waveCount++;
            waveCountTxt.text = "Wave: " + waveCount;
            Debug.Log("Wave 1 down");
            waveTenIsDown = true;
            // You can add additional logic here for what happens when the wave is cleared
        }

        if (!uiShopItems.activeSelf)
        {
            float rotationAboutY = cameraRotationSpeed * Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, rotationAboutY, 0));

            float rotationAboutX = -cameraRotationSpeed * Input.GetAxis("Mouse Y");
            camera.transform.Rotate(new Vector3(rotationAboutX, 0, 0));

            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
        }


        if ((vertical != 0 || horizontal != 0) && !footStep.isPlaying)
        {
            footStep.Play();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementspeed = 5f;
            footStep.pitch = 1.2f;
        }
        else
        {
            movementspeed = 3f;
            footStep.pitch = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter Pressed");
            if (gunInHand.activeSelf || gunInHandSecond.activeSelf)
            {
                if (this.gameObject.transform.position.y < 1.25 || checkRockDoor.getRockDoorStatus() == true)
                {
                    Debug.Log("too low");
                    instructionTextCave.gameObject.SetActive(true);
                    Invoke("DisabInstructionTextCave", 2f);


                }
                else if (waveCount == 1)
                {
                    Debug.Log("gun in hand");
                    mainCamera.SetActive(false);
                    introCamera.SetActive(true);
                    instructionText.enabled = false;
                    // Find all objects with the "Enemy" tag, including inactive ones
                    mutantsWaveOne.SetActive(true);

                }
                else if (waveCount == 2)
                {
                    Debug.Log("gun in hand");
                    mainCamera.SetActive(false);
                    introCamera.SetActive(true);
                    instructionText.enabled = false;
                    // Find all objects with the "Enemy" tag, including inactive ones
                    mutantsWaveTwo.SetActive(true);

                }
                else if (waveCount == 3)
                {
                    Debug.Log("gun in hand");
                    mainCamera.SetActive(false);
                    introCamera.SetActive(true);
                    instructionText.enabled = false;
                    // Find all objects with the "Enemy" tag, including inactive ones
                    mutantsWaveThree.SetActive(true);

                }
                else if (waveCount == 4)
                {
                    Debug.Log("gun in hand");
                    mainCamera.SetActive(false);
                    introCamera.SetActive(true);
                    instructionText.enabled = false;
                    // Find all objects with the "Enemy" tag, including inactive ones
                    mutantsWaveFour.SetActive(true);

                }
                else if (waveCount == 5)
                {
                    Debug.Log("gun in hand");
                    mainCamera.SetActive(false);
                    introCamera.SetActive(true);
                    instructionText.enabled = false;
                    // Find all objects with the "Enemy" tag, including inactive ones
                    mutantsWaveFive.SetActive(true);

                }
                else if (waveCount == 6)
                {
                    Debug.Log("gun in hand");
                    mainCamera.SetActive(false);
                    introCamera.SetActive(true);
                    instructionText.enabled = false;
                    // Find all objects with the "Enemy" tag, including inactive ones
                    mutantsWaveSix.SetActive(true);

                }
                else if (waveCount == 7)
                {
                    Debug.Log("gun in hand");
                    mainCamera.SetActive(false);
                    introCamera.SetActive(true);
                    instructionText.enabled = false;
                    // Find all objects with the "Enemy" tag, including inactive ones
                    mutantsWaveSeven.SetActive(true);

                }
                else if (waveCount == 8)
                {
                    Debug.Log("gun in hand");
                    mainCamera.SetActive(false);
                    introCamera.SetActive(true);
                    instructionText.enabled = false;
                    // Find all objects with the "Enemy" tag, including inactive ones
                    mutantsWaveEight.SetActive(true);

                }
                else if (waveCount == 9)
                {
                    Debug.Log("gun in hand");
                    mainCamera.SetActive(false);
                    introCamera.SetActive(true);
                    instructionText.enabled = false;
                    // Find all objects with the "Enemy" tag, including inactive ones
                    mutantsWaveNine.SetActive(true);

                }
                else if (waveCount == 10)
                {
                    Debug.Log("gun in hand");
                    mainCamera.SetActive(false);
                    introCamera.SetActive(true);
                    instructionText.enabled = false;
                    // Find all objects with the "Enemy" tag, including inactive ones
                    mutantsWaveTen.SetActive(true);

                }

            }
        }

        // Example: Decrease health by 1 every frame (you can adjust as needed)

    }
    bool MutantsWaveOneIsCleared()
    {
        // Check if there are any active mutants in mutantsWaveOne
        foreach (Transform mutant in mutantsWaveOne.transform)
        {
            if (mutant.gameObject.activeSelf)
            {
                return false; // If any mutant is active, the wave is not cleared
            }
        }

        return true; // If no active mutants are found, the wave is cleared
    }
    bool MutantsWaveTwoIsCleared()
    {
        // Check if there are any active mutants in mutantsWaveOne
        foreach (Transform mutant in mutantsWaveTwo.transform)
        {
            if (mutant.gameObject.activeSelf)
            {
                return false; // If any mutant is active, the wave is not cleared
            }
        }

        return true; // If no active mutants are found, the wave is cleared
    }

    bool MutantsWaveThreeIsCleared()
    {
        // Check if there are any active mutants in mutantsWaveOne
        foreach (Transform mutant in mutantsWaveThree.transform)
        {
            if (mutant.gameObject.activeSelf)
            {
                return false; // If any mutant is active, the wave is not cleared
            }
        }

        return true; // If no active mutants are found, the wave is cleared
    }

    bool MutantsWaveFourIsCleared()
    {
        // Check if there are any active mutants in mutantsWaveOne
        foreach (Transform mutant in mutantsWaveFour.transform)
        {
            if (mutant.gameObject.activeSelf)
            {
                return false; // If any mutant is active, the wave is not cleared
            }
        }

        return true; // If no active mutants are found, the wave is cleared
    }

    bool MutantsWaveFiveIsCleared()
    {
        // Check if there are any active mutants in mutantsWaveOne
        foreach (Transform mutant in mutantsWaveFive.transform)
        {
            if (mutant.gameObject.activeSelf)
            {
                return false; // If any mutant is active, the wave is not cleared
            }
        }

        return true; // If no active mutants are found, the wave is cleared
    }
    bool MutantsWaveSixIsCleared()
    {
        // Check if there are any active mutants in mutantsWaveOne
        foreach (Transform mutant in mutantsWaveSix.transform)
        {
            if (mutant.gameObject.activeSelf)
            {
                return false; // If any mutant is active, the wave is not cleared
            }
        }

        return true; // If no active mutants are found, the wave is cleared
    }
    bool MutantsWaveSevenIsCleared()
    {
        // Check if there are any active mutants in mutantsWaveOne
        foreach (Transform mutant in mutantsWaveSeven.transform)
        {
            if (mutant.gameObject.activeSelf)
            {
                return false; // If any mutant is active, the wave is not cleared
            }
        }

        return true; // If no active mutants are found, the wave is cleared
    }
    bool MutantsWaveEightIsCleared()
    {
        // Check if there are any active mutants in mutantsWaveOne
        foreach (Transform mutant in mutantsWaveEight.transform)
        {
            if (mutant.gameObject.activeSelf)
            {
                return false; // If any mutant is active, the wave is not cleared
            }
        }

        return true; // If no active mutants are found, the wave is cleared
    }
    bool MutantsWaveNineIsCleared()
    {
        // Check if there are any active mutants in mutantsWaveOne
        foreach (Transform mutant in mutantsWaveNine.transform)
        {
            if (mutant.gameObject.activeSelf)
            {
                return false; // If any mutant is active, the wave is not cleared
            }
        }

        return true; // If no active mutants are found, the wave is cleared
    }
    bool MutantsWaveTenIsCleared()
    {
        // Check if there are any active mutants in mutantsWaveOne
        foreach (Transform mutant in mutantsWaveTen.transform)
        {
            if (mutant.gameObject.activeSelf)
            {
                return false; // If any mutant is active, the wave is not cleared
            }
        }

        return true; // If no active mutants are found, the wave is cleared
    }


    void DisabInstructionTextCave()
    {
        instructionTextCave.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        
            Vector3 direction = new Vector3(movementspeed * horizontal, -5, movementspeed * vertical);
            direction = transform.TransformDirection(direction);
            cController.Move(direction * Time.fixedDeltaTime);
        
    }

    // Function to decrease health
    public void DecreaseHealth(int amount)
    {
        health -= amount;
        healthText.text = ("HP: " + health);
        Debug.Log(health);
        // Example: Check if health is zero or below
        if (health <= 0)
        {
            // You can add code here to handle player death or other actions
            // For example, you might respawn the player or end the game.
            Debug.Log("Player has died!");
        }
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
        health = Mathf.Min(health, 100); // Ensure health doesn't exceed 100
        healthText.text = ("HP: " + health);
        Debug.Log(health);
        // You can add additional logic here if needed
    }
}
