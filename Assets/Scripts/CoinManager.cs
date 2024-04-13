using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public int coins ;
    public Text coinNum;
    public GameObject targetObject;
    private Text textComponent;
    public Font customFont;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    void Start(){
       
    }

    void Update()
    {
        coinNum.text = "Coin Count: " + coins.ToString();
    }

    public void AddCoin()
    {
        coins++;
        if (coins == 100)
        {
            GameManager.Instance.AddLife();
        }
    }

    
    public void ResetCoins(){
        coins = 0;
    }

    public void UpdateScene(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void ResetScene(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 生成一个text
        GameObject textObject = new GameObject("CoinNumber");
        textComponent = textObject.AddComponent<Text>();

        textComponent.text = coins.ToString();
        textComponent.font = customFont;
        textComponent.fontSize = 110;
        textComponent.color = new Color(242f / 255f, 1f, 0f);
        textComponent.alignment = TextAnchor.MiddleCenter;

        RectTransform textRectTransform = textComponent.GetComponent<RectTransform>();
        // 设置位置
        textRectTransform.anchoredPosition = new Vector2(275f, 40f); // Inspector 的 Rect Transfrom Pos x 和 Pos y
        // 设置大小
        textRectTransform.sizeDelta = new Vector2(225f, 120f); // 设置宽度为 200，高度为 50


        // 将 Text 对象作为 targetObject 的child
        textObject.transform.SetParent(targetObject.transform, false);
    }

    public void RemoveTextComponent()
    {
        if (textComponent != null)
        {
            Destroy(textComponent.gameObject);
        }
    }

}