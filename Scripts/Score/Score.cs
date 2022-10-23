using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private Transform player;
    public static int ScorePoints { get; set; } = 0;
    public static int LostPoints => 5;
    public static int ScoreForWall => 20;

    private void Start()
    {
        player = gameObject.GetComponent<Transform>();
        BlockRaycast.Boosted += OnBoost;
    }

    private void OnDestroy()
    {
        BlockRaycast.Boosted -= OnBoost;
    }

    //Called on the boost of player
    private void OnBoost() => StartCoroutine(ScoreUp());

    IEnumerator ScoreUp()
    {
        if (CameraWalker.isBoost)
        {
            yield return new WaitForSeconds(2f);
            ScorePoints++;
        }   
    }

    
}
