using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Author Max Nikander
/// Scripting for the pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{

    private Button continueButton;
    private Button toMainMenuButton;

    private GameObject pauseMenuPanel;
    private bool pauseOn = false;

    public bool PauseOn
    {
        get
        {
            return pauseOn;
        }

        set
        {
            pauseOn = value;
        }
    }

    // Use this for initialization
    /// <summary>
    /// Adds references to game objects and listeners for buttons.
    /// </summary>
    void Start()
    {

        continueButton = GameObject.Find("ContinueButton").GetComponent<Button>();
        toMainMenuButton = GameObject.Find("ToMainMenuButton").GetComponent<Button>();

        pauseMenuPanel = GameObject.Find("PauseMenuPanel");
        pauseMenuPanel.SetActive(false);

        continueButton.onClick.AddListener(() => OnContinueButtonClick());
        toMainMenuButton.onClick.AddListener(() => OnToMainMenuButtonClick());

    }

    // Update is called once per frame
    /// <summary>
    /// Gets inputs from escape key and pauses the game when escape is pressed.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown("escape") && PauseOn == false)
        {
            Debug.Log("Pause On!");
            PauseOn = true;
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown("escape") && PauseOn == true)
        {
            Debug.Log("Pause Off!");
            PauseOn = false;
            pauseMenuPanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    /// <summary>
    /// Continue buttons listener, sets the timescale to 1.0 (default) and closes the pause menu panel.
    /// </summary>
    void OnContinueButtonClick()
    {
        PauseOn = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Main menu buttons listener, loads the scene that contains the main menu.
    /// </summary>
    void OnToMainMenuButtonClick()
    {
        SceneManager.LoadScene("Main Manu");
    }
    /// <summary>
    /// Used to acces the state of pauseOn boolean so that other classes know if the game is currently paused.
    /// </summary>
    /// <returns>pauseOn boolean</returns>
    public bool GetpauseOn()
    {
        return pauseOn;
    }
    }
