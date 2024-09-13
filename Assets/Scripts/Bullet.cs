using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bullet : MonoBehaviour
{
    private float speed = 3.0f;

    private GameManager gameManager;

    private AudioSource audioSource;
    [SerializeField] AudioClip audioClip;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    // ABSTRACTION
    // Method to handle collision and award different points depending on different enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("YellowEnemy"))
        {
            audioSource.PlayOneShot(audioClip);
            gameManager.IncreaseScore(10);

            Destroy(gameObject, 0.3f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("RedEnemy"))
        {
            audioSource.PlayOneShot(audioClip);
            gameManager.IncreaseScore(20);

            Destroy(gameObject,0.3f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("GreenEnemy"))
        {
            audioSource.PlayOneShot(audioClip);
            gameManager.IncreaseScore(30);

            Destroy(gameObject,0.3f);
            Destroy(other.gameObject);
        }
    }


}
