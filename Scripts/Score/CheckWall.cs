using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Score.ScorePoints += Score.ScoreForWall;
            if (!CameraWalker.isBoost)
                StartCoroutine(LostPoints());
        } 
    }
    
    /// <summary>
    /// Lost score points if player is collide
    /// </summary>
    /// <returns></returns>
    IEnumerator LostPoints()
    {
        yield return new WaitForSeconds(1f);
        Score.ScorePoints -= 40;

        if(Score.ScorePoints < 0) Score.ScorePoints = 0;
    }
}
