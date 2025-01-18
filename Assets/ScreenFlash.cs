using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFlash : MonoBehaviour
{
    [SerializeField]
    Material imageMaterial; // this is a shader which will pop up on wrong choice

    private float fadeDuration = 0.5f; // Duration for alpha to reach max
    private Coroutine fadeCoroutine;

    void Start()
    {
        Color temp = imageMaterial.color;
        temp.a = 0f;
        imageMaterial.color = temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnWrongChoice()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(IncreaseAlphaOverTime(fadeDuration, 0f, 0.2f));
        fadeCoroutine = StartCoroutine(IncreaseAlphaOverTime(fadeDuration, 0.2f, 0f));

    }

    private IEnumerator IncreaseAlphaOverTime(float duration, float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        // Get the current color and alpha
        Color color = imageMaterial.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Lerp alpha value from initial to target over the duration
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);

            // Apply the color back to the material
            imageMaterial.color = color;

            yield return null;
        }

        // Ensure the final alpha is set to the target value
        color.a = endAlpha;
        imageMaterial.color = color;


        fadeCoroutine = null;
    }
}
