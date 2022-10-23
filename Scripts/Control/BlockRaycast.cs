using System;
using UnityEngine;

public class BlockRaycast : MonoBehaviour
{
    private Transform block;
    private Vector3 direction;
    private readonly float deltaSpeed = .3f;
    private bool oneTime = false;

    public static event Action Boosted;

    void FixedUpdate()
    {
        #region Speed boost
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            block = gameObject.transform.GetChild(i);
            direction = Vector3.left;

            if (Physics.Raycast(block.transform.position, direction, out RaycastHit hit, GM.Range))
            {
                if (!hit.collider.CompareTag("block") && Boosted != null)
                {
                    PlayerControl.Velocity += deltaSpeed;
                    if (!oneTime)
                    {
                        Boosted(); //For score
                        oneTime = true;
                    }
                } 
                else
                {
                    PlayerControl.Velocity = PlayerControl.ConstSpeed;
                    oneTime = false;
                }
                   
            }
        }
        #endregion
    }
    /// <summary>
    /// Destroying blocks in wall like a main figure
    /// </summary>
    public void DestroyBlocks()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            block = gameObject.transform.GetChild(i);
            direction = Vector3.left;

            if (Physics.Raycast(block.transform.position, direction, out RaycastHit hit, GM.Range))
            {
                if (hit.collider.CompareTag("block"))
                    Destroy(hit.transform.gameObject);
            }
        }
    }
}