using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Author Max Nikander
/// Scripting for the inventory system >WIP<
/// </summary>
public class InventoryScript : MonoBehaviour
{

    // Use this for initialization

    private Button daggersButton;
    private Button healButton;

    private GameObject daggersPanel;
    private GameObject healPanel;

    private GameObject daggersTrashPanel;
    private GameObject healTrashPanel;





    void Start()
    {
        daggersButton = GameObject.Find("DaggersButton").GetComponent<Button>();
        healButton = GameObject.Find("HealButton").GetComponent<Button>();
        daggersPanel = GameObject.Find("DaggersPanel");
        healPanel = GameObject.Find("HealPanel");
        daggersTrashPanel = GameObject.Find("DaggersTrashPanel");
        healTrashPanel = GameObject.Find("HealTrashPanel");
        daggersTrashPanel.SetActive(false);
        healTrashPanel.SetActive(false);
        
        daggersButton.onClick.AddListener(() => ButtonPressed(daggersButton));
        healButton.onClick.AddListener(() => ButtonPressed(healButton));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ButtonPressed(Button button)
    {
        if (button == daggersButton)
        {
            Debug.Log("DaggersButtonPressed");
            daggersPanel.SetActive(false);
            daggersTrashPanel.SetActive(true);

        }
        if (button == healButton)
        {
            Debug.Log("HealButtonPressed");
            healPanel.SetActive(false);
            healTrashPanel.SetActive(true);

        }
    }
}
