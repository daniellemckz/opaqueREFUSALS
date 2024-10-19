using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToLevel : MonoBehaviour
{
    public float level;

    private void OnCollisionEnter(Collision gameObjectInformation)
    {
        if (gameObjectInformation.gameObject.tag == "Player")
        {
            SceneManager.LoadScene((int)level);
        }
    }

}
