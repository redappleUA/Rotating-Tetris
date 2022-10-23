using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    /// <summary>
    /// Default speed
    /// </summary>
    public const float ConstSpeed = 60f;
    /// <summary>
    /// Velocity of the player
    /// </summary>
    public static float Velocity { get; set; }

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SwipeDetection.SwipeEvent += OnSwipe;
        Velocity = ConstSpeed;
    }

    void FixedUpdate()
    {
        Vector3 velocity = rb.velocity;
        velocity.x = -Velocity;
        rb.velocity = velocity;
    }

    private void OnDestroy()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }

    //OnSwipe is called on each swipe
    private void OnSwipe(Vector2 direction) 
    {
        var rotationDirection = direction == Vector2.left ? -90 :
            direction == Vector2.right ? 90 : 0;

        StartCoroutine(Rotation(.5f, Quaternion.Euler(0, rotationDirection, 0)));
    }

    /// <summary>
    /// Animation for rotaion on swipe
    /// </summary>
    /// <param name="totalDuration">Total duration of animation</param>
    /// <param name="rotationAmount">Euler for rotate</param>
    /// <returns></returns>
    IEnumerator Rotation(float totalDuration, Quaternion rotationAmount)
    {
        float elapsedTime = 0f;
        Quaternion lastRotation = Quaternion.identity;

        while (elapsedTime < totalDuration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / totalDuration;

            Quaternion newRotation = Quaternion.Lerp(Quaternion.identity, rotationAmount, percentageComplete);
            transform.rotation *= newRotation * Quaternion.Inverse(lastRotation);

            lastRotation = newRotation;
            yield return null;
        }
    }
}
