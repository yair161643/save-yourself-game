using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerMotion : MonoBehaviour
{
    public GameObject acamera;
    public GameObject originalCrosshair;
    public GameObject touchCrosshair;
    public Text activeText;
    public Text pickGunText;
    Animator animator;
    public GameObject gunInHand;
    public GameObject gunInDrawer;
    AudioSource pickGunAudio;
    public GameObject rockDoor;
    Animator rockDoorAnim;
    private bool isRockDoorOpen = false;
    private bool isColliderActive = true;
    AudioSource audioSourceRockDoor;
    public GameObject uiShop;



    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        uiShop.SetActive(false);
        animator = GetComponent<Animator>();
        pickGunAudio = gunInHand.GetComponent<AudioSource>();
        rockDoorAnim = rockDoor.GetComponent<Animator>();
        audioSourceRockDoor = rockDoor.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (Physics.Raycast(acamera.transform.position, acamera.transform.forward, out hit))
        {
            if (hit.transform.gameObject == this.gameObject)
            {
                originalCrosshair.SetActive(false);
                touchCrosshair.SetActive(true);
                activeText.gameObject.SetActive(true);
                pickGunText.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.E) && isOpen == false)
                {
                    animator.SetBool("Status", true);
                    isOpen = true;
                }
                else if (Input.GetKeyDown(KeyCode.E) && isOpen == true)
                {
                    animator.SetBool("Status", false);
                    isOpen = false;
                }
            }
            else if (hit.transform.gameObject.tag == "HandGun")
            {
                originalCrosshair.SetActive(false);
                touchCrosshair.SetActive(true);
                pickGunText.gameObject.SetActive(true);
                activeText.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gunInHand.SetActive(true);
                    pickGunAudio.Play();
                    gunInDrawer.SetActive(false);

                }
            }
            else if (hit.transform.gameObject.tag == "Computer")
            {
                originalCrosshair.SetActive(false);
                touchCrosshair.SetActive(true);
                pickGunText.gameObject.SetActive(true);
                activeText.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    uiShop.SetActive(true);



                }
            }
            else if (hit.transform.gameObject.tag == "RockDoor")
            {
                // Check if the collider is active before allowing interaction
                if (isColliderActive && enemies.Length == 0)
                {
                    originalCrosshair.SetActive(false);
                    touchCrosshair.SetActive(true);
                    activeText.gameObject.SetActive(true);
                    pickGunText.gameObject.SetActive(false);

                    if (Input.GetKeyDown(KeyCode.E) && isRockDoorOpen == false)
                    {
                        audioSourceRockDoor.Play();
                        rockDoorAnim.SetBool("Status", true);
                        isRockDoorOpen = true;
                        StartCoroutine(DisableColliderForSeconds(5f));  // Disable collider for 5 seconds
                    }
                    else if (Input.GetKeyDown(KeyCode.E) && isRockDoorOpen == true)
                    {
                        audioSourceRockDoor.Play();
                        rockDoorAnim.SetBool("Status", false);
                        isRockDoorOpen = false;
                        StartCoroutine(DisableColliderForSeconds(5f));  // Disable collider for 5 seconds
                    }
                }
            }
            else
            {
                originalCrosshair.SetActive(true);
                touchCrosshair.SetActive(false);
                activeText.gameObject.SetActive(false);
                pickGunText.gameObject.SetActive(false);

            }

            IEnumerator DisableColliderForSeconds(float seconds)
            {
                isColliderActive = false;  // Set the flag to false
                                           // Disable the collider
                hit.transform.GetComponent<Collider>().enabled = false;
                yield return new WaitForSeconds(seconds);  // Wait for the specified duration
                                                           // Enable the collider after waiting
                hit.transform.GetComponent<Collider>().enabled = true;
                isColliderActive = true;  // Set the flag back to true
            }

        }
    }

    public bool getRockDoorStatus()
    {
        return isRockDoorOpen;
    }
}
