using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI timeText;
    
    public int playerHP = 3;
    public float timeRemaining = 300f; 

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateUI();
        }
        else
        {
            GameOver();
        }
    }

    public void TakeDamage()
    {
        playerHP--;
        UpdateUI();

        if (playerHP <= 0)
        {
            GameOver();
        }
    }

    private void UpdateUI()
    {
        hpText.text = "HP: " + playerHP;

        float timeToDisplay = timeRemaining < 0 ? 0 : timeRemaining;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); 

        timeText.text = string.Format("Time: {0:0}:{1:00}", minutes, seconds); 
    }
    
    private void GameOver()
    {
        SceneManager.LoadScene("Lose");
    }
}