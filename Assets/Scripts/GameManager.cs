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
        lives = 10;
        world = 1;
        stage = 0;

        CoinManager.Instance.ResetCoins();
        CoinManager.Instance.ResetScene();

        LoadLevel(world, stage);
    }

    public void GameOver()
    {
        SceneManager.LoadScene($"Game Over");
    }

    public void GameClear()
    {
        SceneManager.LoadScene($"Game Clear");
    }

    public void LoadLevel(int world, int stage)
    {
        // this.world = world;
        // this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void NextLevel()
    {
        stage += 1;

        if(stage < 5){
            LoadLevel(world, stage);
        }else {
            CoinManager.Instance.UpdateScene();
            GameClear();
        }
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
            CoinManager.Instance.UpdateScene();
            GameOver();
        }
    }

    public void AddLife()
    {
        lives++;
    }

}
