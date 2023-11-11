using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManager;

public class PlayScript : MonoBehaviour
{
    public void PlayGame()
        SceneManager.LoadScene("GameMenu");
}
