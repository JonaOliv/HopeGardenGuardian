using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingNPC : MonoBehaviour
{
    public double amountToMove;
    public float moveSpeed;
    private float startX;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        startX = gameObject.transform.position.x; 
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < startX + amountToMove && direction == 0)
        {
            gameObject.transform.position = new Vector2 (gameObject.transform.position.x + moveSpeed, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x >= startX + amountToMove && direction == 0)
        {
            direction = 1;
        }
        else if (gameObject.transform.position.x > startX && direction == 1)
        {
            gameObject.transform.position = new Vector2 (gameObject.transform.position.x - moveSpeed, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x <= startX && direction == 1)
        {
            direction = 0;
        }
    }
}
