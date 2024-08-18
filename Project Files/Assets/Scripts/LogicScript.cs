using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;

    public bool speedNeedsToBeIncreased = false;
    public float pipeMoveSpeed = 5f;
    public float spawnRate = 4;

    public float background1ScrollSpeed = 0.2f;
    public float background2ScrollSpeed = 0.4f;
    public float background3ScrollSpeed = 0.6f;
    public float background4ScrollSpeed = 0.8f;

    [SerializeField] private AudioSource scoreIncreased;
    [SerializeField] private AudioSource buttonPressed;

    //allows access to run this function manually from within Unity
    [ContextMenu("Increase Score")]
    //note: parameter exists so that if there is any future way to add points outside of just passing pipes, 
    //we can use same function. addToScore Plays pointInc sound effect and increases score on screen. Also updates
    //boolean value to true to increase speed of pipes. Only will successfully increase when score is divisible by 5
    //as written in PipeMoveScript.cs
    public void addToScore(int incomingPoints)
    {
        scoreIncreased.Play();
        score += incomingPoints;
        scoreText.text = score.ToString();
        speedNeedsToBeIncreased = true;
    }

    //resets scene
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //turns on gameOver overlay
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    //takes player to Game Scene
    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }

    //Takes player to Credits scene
    public void seeCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    //takes player to Title Menu scene
    public void seeTitleScreen()
    {
        SceneManager.LoadScene("Title Menu");
    }

    //closes the application
    public void quit()
    {
        Application.Quit();
    }

    //plays sound when button is pressed
    public void buttonWasPressed()
    {
        buttonPressed.Play();
    }
}
