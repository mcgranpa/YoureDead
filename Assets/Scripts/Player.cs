using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Player : MonoBehaviour
{
    public static Player _instance;

    [SerializeField] float playerRunSpeed = 10f;
    //[SerializeField] AudioSource playerAudio;
    [SerializeField] private float shootingTimerLimit = 0.2f;
    [SerializeField] Transform bulletSpawnpos;
    [SerializeField] GameObject bullet;
    [SerializeField] TextMeshProUGUI blueKeyText;
    [SerializeField] TextMeshProUGUI countCountText;
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI frogCountText;
    [SerializeField] TextMeshProUGUI gameTimeText;
    [SerializeField] Sprite warriorSprite;
    [SerializeField] SpriteRenderer playerSR;
    [SerializeField] AudioSource backgroundMusic;

    private float shootingTimer;

    private Vector2 targetPos;
    private Vector2 direction;
    private Vector2 bulletPosition;

    // Public
    public int blueKeys = 0;
    public int greenKeys = 0;
    public int redKeys = 0;
    public int yellowKeys = 0;

    public int frogCount = 0;
    public int coinCount = 0;
    public int playerScore = 0;

    public bool isActive = true;

    //
    private Vector3 moveDelta;
    private RaycastHit2D movementHit;
    private BoxCollider2D boxCollider;
    private Rigidbody2D playerRigidBody;
    private Camera mainCam;
    private bool startTimer = false;
    private float gameTime;

    Vector2 moveInput;
    float playerX;
    float playerY;

    private void Awake()
    {
        _instance = this;
        boxCollider = GetComponent<BoxCollider2D>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
        shootingTimer = 0;
    }

    void Start()
    {
        UpdateUI();
    }

    //void FixedUpdate()
    void Update()
    {
        if (!isActive) { return; }
        Run();
        if (startTimer)
        {
            gameTime += Time.deltaTime;
            double d = System.Math.Round(gameTime, 0) ;
            gameTimeText.text = "Time " + d.ToString() + " secs";
        }
        // HandleShooting();
    }

    public void OnMove(InputValue value)
    {
        if (!isActive) { return; }
        moveInput = value.Get<Vector2>();
    }

    public void OnExit(InputValue value)
    {
        // exit without warning to main menu
        SceneManager.LoadScene("MainMenu");
    }

    /*
    // original exit code 
    public void OnExit(InputValue value)
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif    
    }
    */

    private void Run()
    {
        playerX = moveInput.x * playerRunSpeed;
        playerY = moveInput.y * playerRunSpeed;
        playerRigidBody.velocity = new Vector2(playerX, playerY);
        if ( (playerX != 0 || playerY != 0) && startTimer == false)
        {
            startTimer = true;
        }
    }

    //void HandleShooting()
    public void OnFire()

    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //Debug.Log("Fire");
        if (!isActive) { return; }
        if (Time.time > shootingTimer)
            {
                shootingTimer = Time.time + shootingTimerLimit;
                Shoot();
            }

        //}
    }

    public void Shoot()
    {
        targetPos = Mouse.current.position.ReadValue();
        targetPos = mainCam.ScreenToWorldPoint(targetPos);
        bulletPosition = new Vector2(bulletSpawnpos.position.x, bulletSpawnpos.position.y);
        direction = (targetPos - bulletPosition).normalized;

        GameObject newBullet = Instantiate(bullet,
            bulletPosition, Quaternion.identity);
        newBullet.GetComponent<Bullets>().MoveInDirection(direction);
    }

    public void UpdateUI()
    {
        blueKeyText.text = "Blue Keys " + blueKeys.ToString();
        countCountText.text = "Coins " + coinCount.ToString();
        frogCountText.text = "Frogs " + frogCount.ToString();
        playerScoreText.text = "Score " + playerScore.ToString();
    }

    public void MakeAlive()
    {
        backgroundMusic.Stop();
        playerSR.sprite = warriorSprite;
        
    }
}
