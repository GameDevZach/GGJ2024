using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    static public ScoreController instance;

    public int playerPoints = 0;

    [SerializeField]
    private TextMeshProUGUI textUI;

    void Start()
    {
        instance = this;
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
