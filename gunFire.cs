using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class gunFire : MonoBehaviour
{
    public GameObject gun;
    public GameObject target;
    public GameObject aCamera;
    public GameObject startPointMuzzle;
    public GameObject enemy;
    public GameObject hitCrossHair;
    AudioSource audioOfHit;
    int gunMagazine = 15;
    public Text magazineText;
    public bool isReloading = false;
    public bool isCooldown = false;
    Animator animatedGunRelode;
    public GameObject uiShopItems;




    // Start is called before the first frame update
    void Start()
    {
        animatedGunRelode = gun.GetComponent<Animator>();
        audioOfHit = target.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());

        }
        if (gunMagazine == 0 && !isReloading)
        {
            StartCoroutine(Reload());

        }
        if (!isReloading && Input.GetKeyDown(KeyCode.Mouse0) && !isCooldown && !uiShopItems.activeSelf)
        {
            if (gun.gameObject.activeSelf)
            {
                gunMagazine -= 1;
                magazineText.text = gunMagazine + "/15";
                RaycastHit hit;
                if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
                {

                    target.transform.position = hit.point;
                    if (hit.collider.gameObject.CompareTag("Enemy"))
                    {
                        hitCrossHair.SetActive(true);
                        audioOfHit.Play();

                        mutantMotion mutant = hit.collider.GetComponent<mutantMotion>();

                        mutant.DecreaseHealth(35.0f);

                        // Set hitCrossHair to false after 0.2 seconds
                        Invoke("DisableHitCrossHair", 0.1f);
                    }

                    else if (hit.collider.gameObject.CompareTag("Enemy Bear"))
                    {
                        hitCrossHair.SetActive(true);
                        audioOfHit.Play();

                        BearMonsterMotion bearMonster = hit.collider.GetComponent<BearMonsterMotion>();

                        bearMonster.DecreaseHealth(35.0f);

                        // Set hitCrossHair to false after 0.2 seconds
                        Invoke("DisableHitCrossHair", 0.1f);
                    }
                }
                isCooldown = true;
                StartCoroutine(ResetCooldown());


            }
        }
    }

    // Method to set hitCrossHair to false
    void DisableHitCrossHair()
    {
        hitCrossHair.SetActive(false);
    }

    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        isCooldown = false;
        Debug.Log("Cooldown finished");
    }

    IEnumerator Reload()
    {
        if (gun.gameObject.activeSelf)
        {
            animatedGunRelode.SetBool("isReloding", true);
            Debug.Log("Reloading started");
            isReloading = true;
            yield return new WaitForSeconds(3.0f); // Wait for 3 seconds
            gunMagazine = 15; // Reset magazine count
            magazineText.text = gunMagazine + "/15";
            isReloading = false;
            Debug.Log("Reloading finished");
            animatedGunRelode.SetBool("isReloding", false);
        }

    }
}
