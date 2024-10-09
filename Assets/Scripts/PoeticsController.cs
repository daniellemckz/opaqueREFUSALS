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

    // Array of texts, each on a new line for better organization
    private string[] texts =
    {
        "drenched in bubble wrap\r\na far cry from a binary arrival\r\nWhat some would call “a place”\r\nFrom here on out please refer to it as “a where?”\r\n",
        "This is a pressurized space (a where ? )\r\nThis is a pressurized body (aware — ) \r\n",
        "Welcome to my <s> <space=5em> body</s>\r\nA compressed container\r\nCatalyzing\r\nMy <u><space=5em></u>\r\nWith growing unrest\r\nundisturbed here\r\n",
        "Please disturb the space\r\nin order to open it up\r\nand allow itself to be perceived\r\nFor what it is\r\n",
        "Exhaling\r\nAnd perceive its inhabitants\r\n\r\nIt takes time\r\n\r\nWhere-in-here\r\nHolds pieces\r\nFloatation devices\r\nAlready capsize\r\n",
        "Disintergations",
        "but a sweeping transition holding zone\r\nBegging for you to sweep\r\n\tWith a mouse\r\n\tWith a hand\r\n\tWith some space to jump\r\n\tWith an instinct to determine direction\r\n\t\tWhat\r\n\t\tAre\r\n\t\tStatic\r\n\t\tDisintegrations",
        "It exists between a point of departure and arrival\r\nBasking in the suspension of time\r\n",
        ""
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
}
