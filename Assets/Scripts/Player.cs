using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] private float xSpeed = 20f;
    [Tooltip("In m")] [SerializeField] private float xRange = 5f;
    [Tooltip("In m")] [SerializeField] private float yRange = 3f;

    [SerializeField] private float positionPitchFactor = -5f;
    [SerializeField] private float positionYawFactor = -5f;
    [SerializeField] private float controlPitchFactor = -20f;
    [SerializeField] private float controlRollFactor = -20f;

    private float xThrow, yThrow;
    void Start()
    {
        
    }


    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * xSpeed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
}
