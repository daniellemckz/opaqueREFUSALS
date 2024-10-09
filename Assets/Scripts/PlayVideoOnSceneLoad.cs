using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;   // Reference to the VideoPlayer component
    public string enterSceneName;      // The name of the next scene to load

    private bool videoStarted = false;

    // This method is called when another object enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided has the "Player" tag
        if (other.CompareTag("Player") && !videoStarted)
        {
            // Start the video and mark that it has started
            if (videoPlayer != null)
            {
                videoPlayer.Play();
                videoPlayer.loopPointReached += OnVideoEnd;  // Attach the event listener for video end
                videoStarted = true;
            }
        }
    }

    // This method is called when the video finishes playing
    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the next scene when the video ends
        SceneManager.LoadScene(enterSceneName);
    }
}
