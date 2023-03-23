using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private Camera mainCamera;
    private Bounds cameraBounds;

    private void Start()
    {
        mainCamera = Camera.main;
        CalculateCameraBounds();
    }

    private void CalculateCameraBounds()
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2;
        Bounds bounds = new Bounds(mainCamera.transform.position, new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        cameraBounds = bounds;
    }

    public Bounds GetCameraBounds()
    {
        return cameraBounds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
