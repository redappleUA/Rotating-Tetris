using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [SerializeField] List<GameObject> playersPrefabs;
    [SerializeField] GameObject wall;

    /// <summary>
    /// Range for spawn and raycast
    /// </summary>
    public static float Range { get; private set; }

    private GameObject player;
    private BlockRaycast destroyer;
    private readonly Vector3 spawnPosition = new(960.5f, 12, -0.033662033f);
    private Vector3 wallPosition;

    private readonly int wallSpawnQuantity = 3;
    private readonly float[] rotatePlayer = { 90, 180, 270, 0 };
    private readonly float rangeStep = 270;
    private int lastValue;

    void Start()
    {
        wallPosition = wall.transform.position;
        SpawnPlayer();
        StartCoroutine(WallSpawn());
        Range = 1070;
    }

    void SpawnPlayer()
    {
        player = Instantiate(playersPrefabs[Random.Range(0, playersPrefabs.Count)], spawnPosition, Quaternion.identity);
        player.name = "Player";

        destroyer = player.GetComponent<BlockRaycast>();
    }

    /// <summary>
    /// Spawning the walls
    /// </summary>
    /// <returns>Waiting the frame</returns>
    IEnumerator WallSpawn()
    {
        yield return null; //Waiting spawn
        destroyer.DestroyBlocks(); //Making the holes in wall

        for (int i = 0; i < wallSpawnQuantity; i++)
        {
            player.transform.rotation = Quaternion.Euler(0, rotatePlayer[UniqueRandom(0, rotatePlayer.Length)], 0);
            yield return null; //Waiting rotate (for safety)

            Range -= rangeStep;
            wallPosition.x += rangeStep;
            Instantiate(wall, wallPosition, Quaternion.identity); //Spawn the wall
            yield return null; //Waiting spawn

            destroyer.DestroyBlocks(); //Making the holes in wall
        }
        player.transform.rotation = Quaternion.Euler(0, rotatePlayer[UniqueRandom(0, rotatePlayer.Length)], 0); //Last random rotate of player
    }

    /// <summary>
    /// Random.Range without duplicate
    /// </summary>
    /// <param name="min">min range</param>
    /// <param name="max">max range</param>
    /// <returns></returns>
    int UniqueRandom(int min, int max)
     {
        int val = Random.Range(min, max);
        while (lastValue == val)
        {
            val = Random.Range(min, max);
        }
        lastValue = val;
        return val;
     }
}
