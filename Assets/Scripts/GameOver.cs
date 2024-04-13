using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void MoveToScene()
    {
        CoinManager.Instance.RemoveTextComponent();
        GameManager.Instance.NewGame();
        // SceneManager.LoadScene(sceneID);
    } 
  
}
