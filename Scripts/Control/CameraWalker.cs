using UnityEngine;
using System.ComponentModel;

public class CameraWalker : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    private Vector3 boostOffset;
    private float boostSpeed = .01f;
    private readonly float deltaSpeed = .02f;
    public static bool isBoost { get; private set; } = false;

    private record BasicOffset(Vector3 offset);
    /// <summary>
    /// One init for save the start offset
    /// </summary>
    private BasicOffset basicOffset;

    void Start()
    {
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
        basicOffset = new BasicOffset(offset);
        boostOffset = new Vector3(boostSpeed, 0, 0);
    }

    void FixedUpdate()
    {
        transform.position = player.transform.position + offset;

        //Boost
        if (PlayerControl.Velocity > PlayerControl.ConstSpeed + 10)
        {
            offset += boostOffset;
            isBoost = true;
        }
        //Stopping the boost
        else if (offset != basicOffset.offset)
        {
            boostSpeed -= deltaSpeed;
            offset -= boostOffset;
            isBoost = false;
        }
        //Default speed
        else
        {
            offset = basicOffset.offset;
            isBoost = false;
        }
            
    } 
}

//For record type and init from C#9.0
namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit { }
}
