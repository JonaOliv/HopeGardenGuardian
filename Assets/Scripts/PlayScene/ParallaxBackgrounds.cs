using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgrounds : MonoBehaviour
{
    public GameObject cam;
    public float parallaxSpeed;

    public Transform[] backgrounds;
    public float[] startPositions;
    public float[] fInitialPositionOffsets;

    private float length;
    private float cameraPositionX;
    private float cameraPositionY;

    private CameraBounds cameraBounds;
    private float cameraLengthY;
    private float lengthY; // high of one image background parallax

    // Start is called before the first frame update
    void Start()
    {
        length = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;

        cameraBounds = cam.GetComponent<CameraBounds>();
        cameraLengthY = cameraBounds.GetCameraBounds().size.y;
        lengthY = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
        cameraPositionY = cam.transform.position.y + (Mathf.Abs(cameraLengthY - lengthY) / 2);

        Debug.Log("cameraLengthY :" + cameraLengthY);

        for (int i = 0; i < backgrounds.Length; i++)
        {
            startPositions[i] = cam.transform.position.x + (length * fInitialPositionOffsets[i]);
            backgrounds[i].position = new Vector3(startPositions[i], cameraPositionY, backgrounds[i].position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraPositionX = cam.transform.position.x;
        cameraPositionY = cam.transform.position.y + (Mathf.Abs(cameraLengthY - lengthY) / 2);
        float temp = 0.0f;
        float distance = 0.0f;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            temp = cameraPositionX * (1 - parallaxSpeed) + (length * fInitialPositionOffsets[i]);
            distance = cameraPositionX * parallaxSpeed;

            Vector3 newPosition = new Vector3(startPositions[i] + distance, cameraPositionY, backgrounds[i].position.z);

            backgrounds[i].position = newPosition;

            if (temp > startPositions[i] + (length / 2)) startPositions[i] += length;
            else if (temp < startPositions[i] - (length / 2)) startPositions[i] -= length;
        }
    }
}