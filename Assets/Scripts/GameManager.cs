using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int world { 
        get; 
        private set; 
    }
    public int stage { 
        get; 
        private set; 
    }
    public int lives { 
        get; 
        private set; 
    }
    public int coins { 
        get; 
        private set; 
    }

    //public Text TotalCoin;
    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }
    private void Start()
    {
        Application.targetFrameRate = 60;

        NewGame();
    }

    public void NewGame()
    {
        lives = 1;
        coins = 0;
        stage = 0;

        LoadLevel(1, stage);
    }

    public void GameOver()
    {
        SceneManager.LoadScene($"Game Over");
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void NextLevel()
    {
        stage += 1;
        LoadLevel(world, stage);
    }

    public void ResetLevel(float delay)
    {
        CancelInvoke(nameof(ResetLevel));
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives -= 1 ;

        if (lives > 0) {
            LoadLevel(world, stage);
        } else {
            GameOver();
        }
    }

    public void AddCoin()
    {
        coins++;
        Debug.Log(coins);
        if (coins == 100)
        {
            coins = 0;
            AddLife();
        }
    }
    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            TotalCoin.text = "" + coins;
        }
    }*/
    public void AddLife()
    {
        lives++;
    }
}
