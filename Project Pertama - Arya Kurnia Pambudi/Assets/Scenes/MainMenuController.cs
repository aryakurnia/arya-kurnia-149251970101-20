using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("GameplayPong");
        Debug.Log("Created by Arya Kurnia Pambudi - 149251970101 - 20");
    }

    public void OpenAuthor()
    {
        Debug.Log("Created with Unity");
    }
}
