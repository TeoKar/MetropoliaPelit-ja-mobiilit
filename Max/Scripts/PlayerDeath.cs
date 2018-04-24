using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Author Max Nikander.
/// Handles the menu that is opened upon the players death.
/// </summary>
public class PlayerDeath : MonoBehaviour
{
    private PauseMenu pauseTools;
    private GameObject deathMenuPanel;
    private Button restartOnDeathButton;
    private Button toMainMenuOnDeathButton;
    // Use this for initialization
    /// <summary>
    /// Add references to buttons and listeners.
    /// </summary>
    void Start()
    {
        restartOnDeathButton = GameObject.Find("RestartOnDeathButton").GetComponent<Button>();
        toMainMenuOnDeathButton = GameObject.Find("ToMainMenuOnDeathButton").GetComponent<Button>();

        deathMenuPanel = GameObject.Find("DeathMenuPanel");
        deathMenuPanel.SetActive(false);
        
        restartOnDeathButton.onClick.AddListener(() => OnRestartOnDeathButton());
        toMainMenuOnDeathButton.onClick.AddListener(() => OnToMainMenuOnDeathButton());
    }

    /// <summary>
    /// Opens the menu when HP drops to zero
    /// </summary>
    void OnDeath()
    {
        //Acces information from hp class
        //Open the DeathMenuPanel when hp drops to 0
    }
    /// <summary>
    /// Listener for RestartOnDeathButton, restarts the game.
    /// </summary>
    void OnRestartOnDeathButton()
    {

    }
    /// <summary>
    /// Listener for ToMainMenuOnDeathButton, loads the scene wich contains the main menu.
    /// </summary>
    void OnToMainMenuOnDeathButton()
    {
        SceneManager.LoadScene("Main Manu");
    }
}
