using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void PlayGame()
   {
        GameManager.Instance.NextLevel();
   } 
   public void QuitGame()
   {
        Application.Quit();
   } 
   public void UIEnable()
   {
        GameObject.Find("Canvas/Main Menu/UI").SetActive(true);
   } 
}
