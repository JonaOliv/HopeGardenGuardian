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

    public class Background
    {
        public Transform background;
        public float startpos;
        public float fInitialPositionOffset;
    }

    // Start is called before the first frame update
    void Start()
    {
        length = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            startPositions[i] = cam.transform.position.x + (length * fInitialPositionOffsets[i]);
            backgrounds[i].position = new Vector3(startPositions[i], cam.transform.position.y, backgrounds[i].position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraPositionX = cam.transform.position.x;
        cameraPositionY = cam.transform.position.y;
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
