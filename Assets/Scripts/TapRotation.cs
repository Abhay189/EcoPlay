using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TapRotation : MonoBehaviour
{
    public float rotationSpeed = 0;
    public GameObject waterSprite;
    public GameObject mainMenuButton;
    public TMP_Text timerText;
    public float threshold = 1;
    private bool win = false;

    void Start()
    {
        mainMenuButton.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
            rotationSpeed = GenerateRandomNumber(100, 1000);
            // Get input from arrow keys
            float horizontalInput = Input.GetAxis("Horizontal");

            // Rotate the Tap sprite based on the input
            transform.Rotate(Vector3.forward, -horizontalInput * rotationSpeed * Time.deltaTime);

            // Change the width of the Water sprite based on the rotation of the Tap sprite
            if (waterSprite != null)
            {
                float tapRotation = transform.rotation.eulerAngles.z;

                // Calculate the new scale for the Water sprite
                float newScaleX = Mathf.Abs(Mathf.Cos(tapRotation * Mathf.Deg2Rad / 2));

                // Apply the new scale to the Water sprite
                waterSprite.transform.localScale = new Vector3(newScaleX, 4.7552f, 1f);

                if (newScaleX < 0 + threshold)
                {
                if (!win)
                    StartTimer(5f, timerText);
                else
                    StopAllCoroutines();
                }
                else
                {
                    StopAllCoroutines();
                    timerText.text = "";
                }
            }

        if(win)
            mainMenuButton.SetActive(true);
    }

    int GenerateRandomNumber(int min, int max)
    {
        return Random.Range(min, max + 1); // The '+1' ensures that the upper bound is inclusive
    }

    void StartTimer(float duration, TMP_Text textMesh)
    {
        StartCoroutine(RunTimer(duration, textMesh));
    }

    IEnumerator RunTimer(float duration, TMP_Text textMesh)
    {
        float timer = duration;

        while (timer > 0f)
        {
            // Display the current time on the TextMesh
            textMesh.text = "Wait for " + Mathf.Ceil(timer).ToString() + " seconds";

            // Wait for the next frame
            yield return null;

            // Decrease the timer
            timer -= Time.deltaTime;
        }

        // Ensure the timer display shows 0 when the timer completes
        textMesh.text = "Well done!";
        win = true;
    }



}
