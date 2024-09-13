using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ENCAPSULATION
    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            if (value < 0)
                health = 0;
            else
                health = value;
        }
    }
    
    float horizontalInput;
    float verticalInput;

    float speed = 10.0f;
    float xRange = 16.0f;

    [SerializeField] GameObject bullet;

    float timeStart = -0.5f;
    float delayInterval = 1.5f;
    float timeRecord;

    private UIManager uiManager;
    private SpawnManager spawnManager;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

      
    }

    // ABSTRACTION
    // Method for player to take damage
    public void TakeDamage(int damage)
    {
        health -= damage;

        uiManager.UpdateHealth(health);
        if (health <= 0)
        {
            health = 0;
            uiManager.UpdateHealth(health);
            spawnManager.StopRepeating();
            uiManager.DisplayRestartButton();

            Die();
        }

    }

    // ABSTRACTION
    // Method to handle death
    public void Die()
    {
        Destroy(gameObject); // Remove the enemy from the scene
    }


    // ABSTRACTION
    // Method to handle player movement
    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        timeRecord = Time.time;
                
        if(Input.GetKey(KeyCode.Space) && timeRecord > timeStart)
        {
            Fire();
        }

        // Keep player in bounds 
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z > 6.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 6.0f);
        }

        if (transform.position.z < 0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

    }

    // ABSTRACTION
    // Method to handle player firing
    private void Fire()
    {
        audioSource.Play();
        Instantiate(bullet, transform.position, bullet.transform.rotation);
        timeStart += delayInterval;
    }
   
}
