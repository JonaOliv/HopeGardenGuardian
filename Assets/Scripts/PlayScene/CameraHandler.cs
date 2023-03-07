using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public float xOffset;
    public float yOffset;

    public float followSpeed;

    public bool isXLocked;
    public bool isYLocked;

    public float X_DIFFERENCE = 15.0f;
    public float Y_DIFFERENCE = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isXLocked = true;
        isYLocked = false;

        X_DIFFERENCE = Mathf.Abs(transform.position.x * 2 - Mathf.Clamp(player.transform.position.x + xOffset, xMin, xMax));
        Y_DIFFERENCE = Mathf.Abs(transform.position.y * 2 - Mathf.Clamp(player.transform.position.y + yOffset, yMin, yMax));
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x + xOffset, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y + yOffset, yMin, yMax);
        Debug.Log("Camera y = " + y + ", x = " + x);

        if (Mathf.Abs(transform.position.x - x) > X_DIFFERENCE)
            isXLocked = false;

        if (Mathf.Abs(transform.position.y - y) > Y_DIFFERENCE)
            isYLocked = false;
        
        if (!isXLocked)
        {
            x = Mathf.Lerp(transform.position.x, x, Time.deltaTime * followSpeed);
            isXLocked = true;
        } else
            x = transform.position.x;


        if (!isYLocked)
        {
            y = Mathf.Lerp(transform.position.y, y, Time.deltaTime * followSpeed);
            isXLocked = false;
        } else
            y = transform.position.y;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
