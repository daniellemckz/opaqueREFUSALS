using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PoeticsController : MonoBehaviour
{
    public TextMeshProUGUI textToChange; // Reference to the TextMeshProUGUI component
    public Button button; // Reference to the button
    public Canvas canvas; // Reference to opening UI canvas

    // Reference to the script controlling panning
    public MonoBehaviour panningScript;

    // Array of texts, each on a new line for better organization
    private string[] texts =
    {
        "this is a pressurized space (a where?)\r\nthis is a pressurized body (aware) \r\nplease disrupt the space",
        "What some would call a place\r\nfrom here on out please refer to it as\r\n\r\n\r\n\r\n\r\n\r\n\r\n                   a where we",
        "Welcome to my <s> <space=5em> body</s>\r\n   a compressed container\r\n   catalyzing into its multiplicities\r\n   from growing unrest\r\n   undisturbed here",
        "please disrupt the space\r\nin order to open it up\r\nand allow itself to be perceived\r\nwith sincerity",
        "a gaze",
        "contending with the\r\nalready",
        "capsized\r\n\r\n            deflated",
        "w hat   a re   s tatic   d eflations",
        "please",
        "commit to the disruption",
        "by e   haling your breathe\r\n         X",
    };

    // Variable to keep track of the current text index
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the button and text references are valid
        if (button != null && textToChange != null)
        {
            // Attach the ChangeTextOnClick method to the button's onClick event
            button.onClick.AddListener(ChangeTextOnClick);
        }
        else
        {
            Debug.LogError("Button or TextMeshProUGUI is not assigned in the Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "X" key is pressed
        if (Input.GetKeyDown(KeyCode.X))
        {
            HideTextAndButton();
        }
    }

    // Method to change the text when the button is clicked
    void ChangeTextOnClick()
    {
        // Change the text to the next in the array
        textToChange.text = texts[currentIndex];

        // Update the index, wrapping back to 0 if it exceeds the array length
        currentIndex = (currentIndex + 1) % texts.Length;

        Debug.Log("Button clicked. New text: " + textToChange.text);
    }

    // Method to hide the text and button
    void HideTextAndButton()
    {
        // Disable the TextMeshProUGUI and Button components
        textToChange.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);

        Debug.Log("Text and button are now hidden.");
    }

    // Method to disable panning
    void DisablePanning()
    {
        if (panningScript != null)
        {
            panningScript.enabled = false; // Disable the panning script
            Debug.Log("Panning has been disabled.");
        }
        else
        {
            Debug.LogWarning("Panning script reference is missing.");
        }
    }

    // Method to enable panning
    void EnablePanning()
    {
        if (panningScript != null)
        {
            panningScript.enabled = true; // Enable the panning script
            Debug.Log("Panning has been enabled.");
        }
        else
        {
            Debug.LogWarning("Panning script reference is missing.");
        }
    }
}

