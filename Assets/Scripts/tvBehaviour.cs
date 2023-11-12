using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tvBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject correctBin;
    public GameObject successMessage;
    public GameObject wrongMessage;
    public GameObject mainMenu;

    void Start()
    {
        successMessage.SetActive(false);
        wrongMessage.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            rb2d.gravityScale = 1f;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != null)
        {
            Debug.Log("Collision with: " + collision.gameObject.name);
            if (collision.gameObject.name == "trash"){
                successMessage.SetActive(true);

            } else{
                wrongMessage.SetActive(true);
            }
            Destroy(gameObject);
            mainMenu.SetActive(true);
        }
    }

}
