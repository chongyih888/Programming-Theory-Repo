using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text healthText;

    [SerializeField] Text scoreText;

    [SerializeField] Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ABSTRACTION
    // Method to update ui health
    public void UpdateHealth(int health)
    {
        healthText.text = "Health: " + health;
    }

    // ABSTRACTION
    // Method to update ui score
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    // ABSTRACTION
    // Method to restart game
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    // ABSTRACTION
    // Method to display restart game button
    public void DisplayRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

}
