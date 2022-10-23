using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private readonly float timeToStop = .1f;
    private bool isStop = false;

    void Update()
    {
        if (Time.timeScale < .2f)
        {
            isStop = false;
            Time.timeScale = 0;
        }
            
        if (isStop)
            Time.timeScale -= timeToStop;
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameOverScreen>(true).OpenGameOverScreen(Score.ScorePoints);
        isStop = true;
    }
}
