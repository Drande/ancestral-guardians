using System.Collections;
using System.Text;
using UnityEngine;
using TMPro;
using System;

public static class Coroutines {
    public static IEnumerator WriteText(TextMeshProUGUI target, string newText, float delayBetweenLetters = 0.06f, Action onLetter = null)
    {
        var elapsed = 0f;
        var index = 0;
        var stringBuilder = new StringBuilder();

        while (index < newText.Length)
        {
            // Add elapsed time since last frame
            elapsed += Time.deltaTime;

            // Add characters while enough time has passed
            while (elapsed >= delayBetweenLetters && index < newText.Length)
            {
                stringBuilder.Append(newText[index]);
                onLetter?.Invoke();
                index++;
                // Reduce elapsed time by the speed to account for the added character
                elapsed -= delayBetweenLetters;
            }

            // Update the text in one operation
            if(stringBuilder.Length > 0) {
                target.text = stringBuilder.ToString();
            }
            // Wait for the next frame
            yield return null;
        }
    }
}