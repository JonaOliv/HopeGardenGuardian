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

    private float X_DIFFERENCE;
    private float Y_DIFFERENCE;

    public GameObject worldBuilder;
    public Bounds camBounds;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        xMin = 0.0f;
        yMin = 0.0f;

        xMax = worldBuilder.GetComponent<WorldBuilder>().getWorldWidth();
        yMax = worldBuilder.GetComponent<WorldBuilder>().getWorldHeight();

        //X_DIFFERENCE = Mathf.Abs(transform.position.x - player.transform.position.x) * 0.25f;
        //Y_DIFFERENCE = Mathf.Abs(transform.position.y - player.transform.position.y);

        camBounds = CalculateCameraBounds();
        X_DIFFERENCE = camBounds.size.x * 0.05f;
        Y_DIFFERENCE = camBounds.size.y * 0.35f;
    }

    // Update is called once per frame
    void Update()
    {
        float fRightFlipping = player.GetComponent<Player>().fRightFlipping;

        float x = Mathf.Clamp(player.transform.position.x + xOffset * fRightFlipping, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y + yOffset, yMin, yMax);

        /*Debug.Log("y :" + y);*/

        if (transform.position.x < x + X_DIFFERENCE && transform.position.x > x - X_DIFFERENCE)
            x = transform.position.x;
        else
            x = Mathf.Lerp(transform.position.x, x, Time.deltaTime * followSpeed);

        if (transform.position.y < y + Y_DIFFERENCE && transform.position.y > y - Y_DIFFERENCE)
            y = transform.position.y;
        else
            y = Mathf.Lerp(transform.position.y, y, Time.deltaTime * followSpeed);

        transform.position = new Vector3(x, y, transform.position.z);
    }

    private Bounds CalculateCameraBounds()
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        Bounds bounds = new Bounds(Camera.main.transform.position, new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}
