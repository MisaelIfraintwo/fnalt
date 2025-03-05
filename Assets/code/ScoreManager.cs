using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TMP_Text scoreText;
    private int score = 0;
    private int victoryPoints = 700;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        UpdateScoreText(); 
        InvokeRepeating(nameof(AddAutomaticPoints), 1.5f, 1.5f);
    }

    public void AddPoints(int amount)
    {
        score += amount;
        UpdateScoreText();
        CheckVictory();
    }

    void AddAutomaticPoints()
    {
        AddPoints(17);
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntos: " + score;
        }
        else
        {
            Debug.LogError("ño");
        }
    }

    void CheckVictory()
    {
        if (score >= victoryPoints)
        {
            SceneManager.LoadScene("VICTORIA");
        }
    }

}
