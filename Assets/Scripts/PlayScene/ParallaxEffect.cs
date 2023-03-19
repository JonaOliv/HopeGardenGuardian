using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, startpos;
    public float parallaxSpeed;
    public GameObject cam;

    public float fInitialPositionOffset;

    public float PixelsPerUnit;

    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startpos = cam.transform.position.x + (length * fInitialPositionOffset);
        transform.position = new Vector3(startpos, transform.position.y, transform.position.z);
        /*
        cameraPreviousPosition = cam.transform.position.x;
        cameraCurrentPosition = cam.transform.position.x;*/
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ParallaxEffect fInitialPositionOffset = " + fInitialPositionOffset);
        // how much it has recorred in relation to its current speed
        float temp = cam.transform.position.x * (1 - parallaxSpeed) + (length * fInitialPositionOffset);  // <--
        float distance = cam.transform.position.x * parallaxSpeed;
        Debug.Log("ParallaxEffect cam.transform.position.x = " + cam.transform.position.x);

        float x = Mathf.Lerp(transform.position.x, startpos + distance, Time.deltaTime * parallaxSpeed);
        Vector3 newPosition = new Vector3(startpos + distance, transform.position.y, transform.position.z);
        Debug.Log("ParallaxEffect startpos + distance = " + (startpos + distance));

        transform.position = PixelPerfectClamp(newPosition, PixelsPerUnit);

        // going ahead and reverse
        if (temp > startpos + (length / 2)) startpos += length;
        else if (temp < startpos - (length / 2)) startpos -= length;
        /*cameraCurrentPosition = cam.transform.position.x;

        if (cameraPreviousPosition == cameraCurrentPosition)
            return;

        float distance = 0.0f;
        if (cameraPreviousPosition > cameraCurrentPosition) 
            distance = - (cam.transform.position.x * parallaxSpeed);
        else
            distance = cam.transform.position.x * parallaxSpeed;

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
        cameraPreviousPosition = cameraCurrentPosition*/

        //Debug.Log("ParallaxEffect startpos = " + startpos + " + distance = " + distance + "; = " + (startpos + distance));
        /*
        cameraCurrentPosition = cam.transform.position.x;
        float parallax = (cameraPreviousPosition - cam.transform.position.x) * 2.5f;

        // Set a target x position which is the current position plus the parallax
        float backgroundTargetPosX = transform.position.x + parallax;

        // Create a target position which is the background's current position with its target x position
        //Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, transform.position.y, transform.position.z);

        Debug.Log("ParallaxEffect transform.position 1 = " + transform.position);
        // Fade between the current position and the target position using lerp
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, backgroundTargetPosX, 1.5f * Time.deltaTime), transform.position.y, transform.position.z);
        cameraPreviousPosition = cameraCurrentPosition;
        Debug.Log("ParallaxEffect transform.position 2 = " + transform.position);
        Debug.Log("ParallaxEffect backgroundTargetPosX = " + backgroundTargetPosX);*/
    }

    private Vector3 PixelPerfectClamp(Vector3 locationVector, float pixelsPerUnit)
    {
        Vector3 vectorInPixels = new Vector3(Mathf.CeilToInt(locationVector.x * pixelsPerUnit), Mathf.CeilToInt(locationVector.y * pixelsPerUnit), Mathf.CeilToInt(locationVector.z * pixelsPerUnit));
        return vectorInPixels / pixelsPerUnit;
    }
}
