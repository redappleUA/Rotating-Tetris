using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBControl : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = false;
        StartCoroutine(LayerControl());

        PlayerControl.Velocity -= 5;
    }

    /// <summary>
    /// So that the blocks do not slow down the figure when they collide
    /// </summary>
    /// <returns></returns>
    IEnumerator LayerControl()
    {
        yield return new WaitForSeconds(1f);
        Physics.IgnoreLayerCollision(7, 6);
        yield return new WaitForSeconds(0.5f);
        Physics.IgnoreLayerCollision(7, 6, false);

        PlayerControl.Velocity = PlayerControl.ConstSpeed;
    }
}
