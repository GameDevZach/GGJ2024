using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    static public ScoreController instance;

    public int playerPoints = 0;

    public int secondsLeft = 50;
    private float currentSecond = 1;
    
    [SerializeField]
    private TextMeshProUGUI textUI;
    [SerializeField]
    private TextMeshProUGUI timerUI;

    void Start()
    {
        instance = this;
    }

    private void Update()
    {
        currentSecond -= Time.deltaTime;
        if (currentSecond <= 0)
        {
            currentSecond += 1;
            secondsLeft -= 1;
            timerUI.text = "Time: " + secondsLeft.ToString();
            if(secondsLeft < 0)
            {
                Debug.Log("Gameover");
                SceneManager.LoadScene("ScoreScene");
            }
        }
    }

    public void DecrementPoints(int amnt)
    {
        playerPoints -= amnt;
        UpdatePointUI();
    }

    public void AddPoints(int amnt)
    {
        playerPoints += amnt;
        UpdatePointUI();
    }

    private void UpdatePointUI()
    {
        textUI.text = "Score: " + playerPoints.ToString();
        PlayerPrefs.SetInt("Points", playerPoints);
    }
}
