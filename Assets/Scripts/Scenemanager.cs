using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager: MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Detta gör så att den laddar nästa scen i sceneindex
    }

    public void QuitGame()
    {
        Debug.Log("Quit"); //Eftersom detta inte fungerar i unity editor så kollar man så det fungerar i debug

        Application.Quit(); //Säger till Application att stänga ner
    }
}
