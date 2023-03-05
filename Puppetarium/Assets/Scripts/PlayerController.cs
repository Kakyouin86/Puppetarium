using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Cinemachine;
using JetBrains.Annotations;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public Player rewiredPlayer;
    public GameObject playerSquare;
    public GameObject playerTriangle;
    public GameObject playerCircle;
    public int activePlayer = 1;
    public Rigidbody2D theRB;
    public float xRaw;
    public float yRaw;
    public float moveSpeed = 5;
    public float moveSpeedModifier = 1;
    public float jumpForce;

    #endregion

    void Awake()
    {
        rewiredPlayer = ReInput.players.GetPlayer(0);
        playerSquare = GameObject.FindGameObjectWithTag("Square");
        playerTriangle = GameObject.FindGameObjectWithTag("Triangle");
        playerCircle = GameObject.FindGameObjectWithTag("Circle");
        activePlayer = 1;
        theRB = playerSquare.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        ChooseYourCharacter();
        Movement();
        Actions();
    }

    #region ChooseYourCharacter
    public void ChooseYourCharacter()
    {
        switch (Input.inputString)
        {
            case "1":
            {
                Debug.Log("Player Square selected");
                activePlayer = 1;
                theRB = playerSquare.GetComponent<Rigidbody2D>();
                }
                break;

            case "2":
            {
                Debug.Log("Player Triangle selected");
                activePlayer = 2;
                theRB = playerTriangle.GetComponent<Rigidbody2D>();
                }
                break;

            case "3":
            {
                Debug.Log("Player Circle selected");
                activePlayer = 3;
                theRB = playerCircle.GetComponent<Rigidbody2D>();
                }
                break;
        }
    }
    #endregion

    #region Movement
    public void Movement()
    {
        xRaw = rewiredPlayer.GetAxisRaw("Horizontal");
        yRaw = rewiredPlayer.GetAxisRaw("Vertical");
        theRB.velocity = new Vector2(rewiredPlayer.GetAxisRaw("Horizontal") * moveSpeed * moveSpeedModifier, theRB.velocity.y);
    }
    #endregion

    #region Actions
    public void Actions()
    {
        if (rewiredPlayer.GetButtonDown("Action 1"))
        {
            Debug.Log("Action 1 pressed");
            switch (activePlayer)
            {
                case 1:
                    theRB.velocity = Vector2.up * jumpForce;
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        if (rewiredPlayer.GetButtonDown("Action 2"))
        {
            Debug.Log("Action 2 pressed");
        }
    }
    #endregion

    public void SelectSquare()
    {
        activePlayer = 1;
        theRB = playerSquare.GetComponent<Rigidbody2D>();
    }

    public void SelectTriangle()
    {
        activePlayer = 2;
        theRB = playerTriangle.GetComponent<Rigidbody2D>();
    }

    public void SelectCircle()
    {
        activePlayer = 3;
        theRB = playerCircle.GetComponent<Rigidbody2D>();
    }
}
