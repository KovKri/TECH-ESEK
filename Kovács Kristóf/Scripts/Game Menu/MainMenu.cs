using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //azert kell h jeleneteket tudjuk valtogatni

public class MainMenu : MonoBehaviour
{
      public void PlayGame()
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Indexeljuk a Scene -eket
      }
      public void QuitGame()
      {
        Debug.Log("QUIT!"); //ellenorzeshez kell
        Application.Quit(); //kiléptet a jatekbol
      }

}
