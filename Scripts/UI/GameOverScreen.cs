using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverScreen : MonoBehaviour
{
    private Label score;
    private Button restartButton;
    private Button nextButton;
    private Button exitButton;

    private void Awake() => gameObject.SetActive(false);
    public void RestartButtonPressed()
    {
        Time.timeScale = 1;
        Score.ScorePoints = 0;
        SceneManager.LoadScene("Game");
    }
    public void NextButtonPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void ExitButtonPressed() => Application.Quit();
    public void OpenGameOverScreen(int scorePoint)
    {
        gameObject.SetActive(true);

        var root = GetComponent<UIDocument>().rootVisualElement;

        restartButton = root.Q<Button>("RestartButton");
        nextButton = root.Q<Button>("NextButton");
        exitButton = root.Q<Button>("ExitButton");
        score = root.Q<Label>("ScoreLabel");

        restartButton.clicked += RestartButtonPressed;
        nextButton.clicked += NextButtonPressed;
        exitButton.clicked += ExitButtonPressed;

        score.text = scorePoint.ToString() + " Points";
        score.style.display = DisplayStyle.Flex;
    }
}