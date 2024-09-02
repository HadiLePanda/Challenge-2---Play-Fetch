using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpawnManagerX spawnManager;

    [Header("Settings")]
    public int startingLives = 3;
    public float scoreRequiredToWin = 5;

    private int livesRemaining = 3;
    private int score = 0;
    private bool gameInProgress = false;

    public int LivesRemaining => livesRemaining;
    public int Score => score;
    public bool IsGameInProgress => gameInProgress;

    public static GameManager singleton;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        // setup lives and change game state
        livesRemaining = startingLives;
        gameInProgress = true;
    }

    private void Update()
    {
        if (!gameInProgress)
            return;

        // check if we lost the game
        if (HasLostGame())
        {
            GameOver();
            return;
        }

        // check if we won the game
        if (HasWonGame())
        {
            GameWin();
            return;
        }
    }

    public bool HasLostGame() => livesRemaining <= 0;
    public bool HasWonGame() => score >= scoreRequiredToWin;

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameInProgress = false;
        spawnManager.DisableSpawning();
    }

    public void GameWin()
    {
        Debug.Log("Game Won!");
        gameInProgress = false;
        spawnManager.DisableSpawning();
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"Score: {amount}");
    }

    public void LoseLife(int amount)
    {
        livesRemaining = Mathf.Max(0, livesRemaining -= amount);
        Debug.Log($"Remaining Lives: {livesRemaining}");
    }
}
