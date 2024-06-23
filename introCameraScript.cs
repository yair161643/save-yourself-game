using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introCameraScript : MonoBehaviour
{
    public GameObject mainCamera;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AfterDoneFirstShot()
    {
        this.gameObject.transform.position = new Vector3(121.46f, 10.7f, 20.15f);
        animator.SetInteger("Status", 1);
    }

    public void StarttheGame()
    {
        mainCamera.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
