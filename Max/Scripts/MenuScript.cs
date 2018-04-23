using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Author Max Nikander
/// Scripting for the main menu scene.
/// </summary>
public class MenuScript : MonoBehaviour
{


    private Button startButton;
    private Button creditsButton;
    private Button backButton;
    private Button exitButton;

    private GameObject mainMenuPanel;
    private GameObject creditsMenuPanel;


    // Use this for initialization
    /// <summary>
    /// Add references to game objects and listeners to buttons.
    /// </summary>
    void Start()
    {
        mainMenuPanel = GameObject.Find("MainMenuPanel");
        creditsMenuPanel = GameObject.Find("CreditsMenuPanel");

        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        creditsButton = GameObject.Find("CreditsButton").GetComponent<Button>();
        backButton = GameObject.Find("BackButton").GetComponent<Button>();
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();

        startButton.onClick.AddListener(()=> OnStartButtonClick());
        creditsButton.onClick.AddListener(() => OnCreditsButtonClick());
        backButton.onClick.AddListener(() => OnBackButtonClick());
        exitButton.onClick.AddListener(() => OnExitButtonClick());

        creditsMenuPanel.SetActive(false);


    }
    /// <summary>
    /// Listener for the exit button, quits the game.
    /// </summary>
    void OnExitButtonClick()
    {
        Debug.Log("Exit Button Clicked");
        Application.Quit();
    }
    /// <summary>
    /// Listener for the start button, loads the scene where that game starts.
    /// </summary>
    void OnStartButtonClick()
    {
        Debug.Log("Start Button Clicked");
        SceneManager.LoadScene("Game");
    }
    /// <summary>
    /// Listener for credits button, opens the credits panel.
    /// </summary>
    void OnCreditsButtonClick()
    {
        Debug.Log("Credits Button Clicked");
        mainMenuPanel.SetActive(false);
        creditsMenuPanel.SetActive(true);
    }
    /// <summary>
    /// Listener for the back button when in the credits panel, closes the credits panel and opens the main menu panel.
    /// </summary>
    void OnBackButtonClick()
    {
        Debug.Log("Back Button Clicked");
        creditsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

}
