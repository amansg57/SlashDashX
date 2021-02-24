using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls camera, smoothly readjusting closer to the midpoint between the 2 fighters when the midpoint changes past a certain bounds
public class CameraScript : MonoBehaviour
{

    public float arenaBounds;

    private Camera mainCamera;

    private const float aspectRatio = 16f / 9f;
    private const float pushActivationPadding = 1f;
    private const float midPushPadding = 2f;
    private float smoothTime = 0.2f;
    private float targetXPosition = 0;
    private Vector3 velocity = Vector3.zero; 

    private void Awake() 
    {
        mainCamera = GetComponent<Camera>();
    }

    public void updateCamera(float leftPlayerPos, float rightPlayerPos)
    {
        float playerMidPoint = (leftPlayerPos + rightPlayerPos) / 2;

        if (playerMidPoint > transform.position.x + midPushPadding) {
            targetXPosition = playerMidPoint - midPushPadding;
        }
        else if (playerMidPoint < transform.position.x - midPushPadding) {
            targetXPosition = playerMidPoint + midPushPadding;
        }

        if (targetXPosition > arenaBounds) {
            targetXPosition = arenaBounds;
        }
        else if (targetXPosition < -arenaBounds) {
            targetXPosition = -arenaBounds;
        }

        Vector3 targetPosition = new Vector3(targetXPosition, transform.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }

}
