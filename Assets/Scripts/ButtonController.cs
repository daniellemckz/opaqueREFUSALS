using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Level 1";
   public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}