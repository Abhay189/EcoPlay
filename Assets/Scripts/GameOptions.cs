using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour
{
    public void redirectToTreeGame() 
    {
        SceneManager.LoadScene("Tree Game");
    }

    public void redirectToWasteSorter() 
    {
        SceneManager.LoadScene("WasteSorter");
    }

    public void redirectToLeakyFaucet() 
    {
        SceneManager.LoadScene("LeakyFaucet");
    }
}
