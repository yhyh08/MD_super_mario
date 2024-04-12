using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public int  Coin = 0;
    public Text CoinNum;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "collection")
        {
            Coin += 1;
            CoinNum.text = Coin.ToString();
        }
    }
    
    // Start is called before the first frame update
    public void MoveToScene()
    {
        GameManager.Instance.NewGame();
        // SceneManager.LoadScene(sceneID);
    } 
  
}
