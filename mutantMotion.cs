using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mutantMotion : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    public GameObject target;
    private float detectionDistance = 15f;
    AudioSource attackAudio;

    // Health properties for mutants
    public float maxHealth = 100.0f;
    public float currentHealth;
    FloatingHealthBar healthBar;

    public Canvas canvas;

    public GameObject healthPackDrop;
    public GameObject meatDrop;

    public Transform transformForHealthPack;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        attackAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;

        Invoke("ActivateAgent", 5f);

    }

    // Update is called once per frame
    void Update()
    {

        if (agent.enabled)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);


            // Check if the distance to the target is less than or equal to the detection distance
            if (distanceToTarget <= detectionDistance)
            {
                // Set the "Status" to 2
                animator.SetInteger("Status", 2);

                agent.isStopped = true;

            }
            else
            {
                // Set the "Status" to 1 if the distance is greater than the detection distance
                animator.SetInteger("Status", 0);


                agent.isStopped = false;

                // Set the destination if needed
                agent.SetDestination(target.transform.position);
            }
        }
    }

    // Function to decrease health
    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Mutant Health: " + currentHealth);
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        // Check if the mutant is dead
        if (currentHealth <= 0)
        {
            // Perform actions for a dead mutant (e.g., play death animation, destroy the mutant GameObject)
            canvas.enabled = false;
            agent.enabled = false;
            CapsuleCollider CC = GetComponent<CapsuleCollider>();
            Rigidbody rb = GetComponent<Rigidbody>();
            animator.SetInteger("Status", 1);
            CC.enabled = false;
            rb.isKinematic = true;
            this.gameObject.tag = "deadEnemy";

            float delay = 5f;
            Invoke("DestroyMutant", delay);

        }
    }

    void DestroyMutant()
    {
        Destroy(this.gameObject);
        DropTheLoot();

    }

    void DropTheLoot()
    {
        System.Random rnd = new System.Random();
        int num = rnd.Next(0, 3);
        Vector3 position = transform.position;
        if(num == 0)
        {
            GameObject drop = Instantiate(healthPackDrop, position + new Vector3(0, 1, 0), Quaternion.identity);

        }
        else if(num == 1||num == 2)
        {
            GameObject drop = Instantiate(meatDrop, position + new Vector3(0, 1, 0), Quaternion.identity);

        }
    }

    public void AttackANimation()
    {
        attackAudio.Play();
        // Check if the player is within a distance of 10 units
        float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
        if (distanceToPlayer <= 15f)
        {
            // Call DecreaseHealth on the player with a value of 10
            target.GetComponent<PlayerMotion>().DecreaseHealth(10);
        }
    }

    void ActivateAgent()
    {
        // Activate the NavMeshAgent after the delay

        // Debugging: Output the current animation state and "Status" parameter value
        Debug.Log("Current Animation State: " + animator.GetCurrentAnimatorStateInfo(0).fullPathHash);
        Debug.Log("Status Parameter Value: " + animator.GetInteger("Status"));

        // Set the "Status" to 3
        animator.SetInteger("Status", 3);
        agent.enabled = true;
    }

}
