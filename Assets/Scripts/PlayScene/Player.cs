using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private Transform onLandStatus;
    public LayerMask landType;
    public float landCheckRadio;
    private bool isOnPlatform;
    public const int MAX_SPEED = 3;
    public const float movementSpeed = 1.5f;
    private float _currentSpeed;
    public const int atleticsJump = 5;

    //Animation Section
    public PlayerAnimation playerAnimation;
    private int _horizontalInput;
    private SpriteRenderer _renderer;
    private bool _rightFlip;

    private float _fRightFlipping;
    public float fRightFlipping => _fRightFlipping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onLandStatus = this.transform.GetChild(0).GetComponent<Transform>();

        _renderer = GetComponent<SpriteRenderer>();

        _currentSpeed = 0;

        _fRightFlipping = 1.0f;


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player y = " + this.transform.position.y + ", x = " + this.transform.position.x);

        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            _currentSpeed = Mathf.Min(_currentSpeed + movementSpeed * Time.deltaTime, MAX_SPEED);
            rb.velocity = new Vector2 (-_currentSpeed, rb.velocity.y);
            playerAnimation.moveWithSpeed(_currentSpeed);
            _renderer.flipX = true;

            _fRightFlipping = -(1.0f);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _currentSpeed = 0;
            playerAnimation.setIdle();
        }

        if(Input.GetKey(KeyCode.RightArrow)) 
        {
            _currentSpeed = Mathf.Min(_currentSpeed + movementSpeed * Time.deltaTime, MAX_SPEED);
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
            playerAnimation.moveWithSpeed(_currentSpeed);
            _renderer.flipX = false;

            _fRightFlipping = 1.0f;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _currentSpeed = 0;
            playerAnimation.setIdle();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(isOnPlatform)  
                rb.velocity = new Vector2(rb.velocity.x, atleticsJump);
        }
    }

    private void FixedUpdate()
    {
        isOnPlatform = Physics2D.OverlapCircle(onLandStatus.position,landCheckRadio,landType);
    }
}
