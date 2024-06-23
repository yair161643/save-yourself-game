using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MOneGun : MonoBehaviour
{
    public GameObject casingPrefab;
    public GameObject gun;
    public GameObject target;
    public GameObject aCamera;
    public GameObject startPointMuzzle;
    public GameObject enemy;
    public GameObject hitCrossHair;
    AudioSource audioOfHit;
    int gunMagazine = 25;
    public Text magazineText;
    public bool isReloading = false;
    Animator animatedGunRelode;
    AudioSource gunShot;
    float fireRate = 0.15f;  // Adjust this value for the firing rate
    float nextFireTime = 0f;
    public GameObject muzzleFlashPrefab;
    [SerializeField] private Transform casingExitLocation;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;


    public GameObject magOneForSound;
    public GameObject magTwoForSound;
    AudioSource soundOfmagazineOut;
    AudioSource soundOfmagazineIn;

    // Start is called before the first frame update
    void Start()
    {
        animatedGunRelode = gun.GetComponent<Animator>();
        audioOfHit = target.GetComponent<AudioSource>();
        gunShot = GetComponent<AudioSource>();
        soundOfmagazineOut = magOneForSound.GetComponent<AudioSource>();
        soundOfmagazineIn = magTwoForSound.GetComponent<AudioSource>();
        if (gun.gameObject.activeSelf)
        {
            magazineText.text = gunMagazine + "/25";
        }
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

        if (!isReloading && Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            if (gun.gameObject.activeSelf)
            {
                gunMagazine -= 1;
                magazineText.text = gunMagazine + "/25";
                gunShot.Play();
                GameObject tempCasing;
                tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
                tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
                //Add torque to make casing spin in random direction
                tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);
                if (muzzleFlashPrefab)
                {
                    GameObject tempFlash = Instantiate(muzzleFlashPrefab, startPointMuzzle.transform.position, startPointMuzzle.transform.rotation);
                    Destroy(tempFlash, 2f);  // Adjust the destroy timer as needed
                }

                RaycastHit hit;
                if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
                {
                    target.transform.position = hit.point;

                    if (hit.collider.gameObject.CompareTag("Enemy"))
                    {
                        hitCrossHair.SetActive(true);
                        audioOfHit.Play();

                        mutantMotion mutant = hit.collider.GetComponent<mutantMotion>();
                        mutant.DecreaseHealth(30.0f);

                        // Set hitCrossHair to false after 0.2 seconds
                        Invoke("DisableHitCrossHair", 0.1f);
                    }
                    else if (hit.collider.gameObject.CompareTag("Enemy Bear"))
                    {
                        hitCrossHair.SetActive(true);
                        audioOfHit.Play();

                        BearMonsterMotion bearMonster = hit.collider.GetComponent<BearMonsterMotion>();
                        bearMonster.DecreaseHealth(30.0f);

                        // Set hitCrossHair to false after 0.2 seconds
                        Invoke("DisableHitCrossHair", 0.1f);
                    }
                }
            }
        }
    }

    void DisableHitCrossHair()
    {
        hitCrossHair.SetActive(false);
    }

    void MagazineOutSound()
    {
        soundOfmagazineOut.Play();
    }
    void MagazineInSound()
    {
        soundOfmagazineIn.Play();
    }

    IEnumerator Reload()
    {
        if (gun.gameObject.activeSelf)
        {
            animatedGunRelode.SetBool("isReloding", true);
            Debug.Log("Reloading started");
            isReloading = true;
            yield return new WaitForSeconds(3.0f); // Wait for 3 seconds
            gunMagazine = 25; // Reset magazine count
            magazineText.text = gunMagazine + "/25";
            isReloading = false;
            Debug.Log("Reloading finished");
            animatedGunRelode.SetBool("isReloding", false);
        }


    }
}
