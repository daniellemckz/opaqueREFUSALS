using UnityEngine;

public class AnimationLoopAndFadeOut : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvasGroup;
    private bool fadeOutStarted = false;
    private float fadeOutDuration = 30.0f; // Duration for the fade out in seconds
    private float fadeOutTimer = 0.0f;
    private int loopCount = 0;
    public int maxLoops = 4;

    void Start()
    {
        // Get the Animator component and add a CanvasGroup if not already present
        animator = GetComponent<Animator>();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
        canvasGroup.alpha = 1.0f; // Set initial alpha to fully visible
    }

    void Update()
    {
        // Track the number of animation loops
        if (animator != null && !fadeOutStarted && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            loopCount++;

            // Reset the animation state to allow looping
            animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, -1, 0f);
        }

        // Check if the animation has looped the required number of times and start fade out
        if (loopCount >= maxLoops && !fadeOutStarted)
        {
            fadeOutStarted = true;
        }

        // Handle the fade-out effect
        if (fadeOutStarted)
        {
            fadeOutTimer += Time.deltaTime;
            float fadeAmount = 1.0f - (fadeOutTimer / fadeOutDuration);
            canvasGroup.alpha = Mathf.Clamp01(fadeAmount); // Gradually reduce alpha

            // If the fade-out is complete, disable the GameObject
            if (canvasGroup.alpha <= 0.0f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
