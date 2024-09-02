using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("References")]
    public TMP_Text livesText;
    public TMP_Text scoreText;
    public Slider scoreSlider;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    private void Start()
    {
        // setup score slider UI
        scoreSlider.minValue = 0;
        scoreSlider.maxValue = GameManager.singleton.scoreRequiredToWin;
        scoreSlider.value = GameManager.singleton.Score;
    }
    private void Update()
    {
        // update lives and score values on the UI
        livesText.text = GameManager.singleton.LivesRemaining.ToString();
        scoreText.text = $"{GameManager.singleton.Score}/{GameManager.singleton.scoreRequiredToWin}";
        scoreSlider.value = GameManager.singleton.Score;

        // handle showing the game over UI
        if (GameManager.singleton.LivesRemaining <= 0)
            gameOverPanel.SetActive(true);
        else
            gameOverPanel.SetActive(false);

        // handle showing the game win UI
        if (GameManager.singleton.Score >= GameManager.singleton.scoreRequiredToWin)
            gameWinPanel.SetActive(true);
        else
            gameWinPanel.SetActive(false);
    }

    public void ReplayGame()
    {
        GameManager.singleton.ReplayGame();
    }
}
