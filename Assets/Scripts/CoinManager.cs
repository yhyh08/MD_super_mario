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
    public AudioClip clip;
    private AudioSource audioSource;
    private int screenWidth;
    private int screenHeight;

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
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // 如果不存在，则添加一个AudioSource组件
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        coinNum.text = "Coin Count: " + coins.ToString();
    }

    public void AddCoin()
    {
        audioSource.clip = clip;
        audioSource.Play();
        coins++;
        if (coins == 30)
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
        
        textComponent.color = new Color(242f / 255f, 1f, 0f);
        textComponent.alignment = TextAnchor.MiddleCenter;

        RectTransform textRectTransform = textComponent.GetComponent<RectTransform>();
        if(screenWidth < 650f || screenHeight < 460f ){
            textComponent.fontSize = 110;
            // 设置位置
            textRectTransform.anchoredPosition = new Vector2(275f, 40f); // Inspector 的 Rect Transfrom Pos x 和 Pos y
            // 设置大小
            textRectTransform.sizeDelta = new Vector2(225f, 120f);
        }else{
            textComponent.fontSize = 100;
            // 设置位置
            textRectTransform.anchoredPosition = new Vector2(105f, 20f); // Inspector 的 Rect Transfrom Pos x 和 Pos y
            // 设置大小
            textRectTransform.sizeDelta = new Vector2(225f, 120f); 
        }
        


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