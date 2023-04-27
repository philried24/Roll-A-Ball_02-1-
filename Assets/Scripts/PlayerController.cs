using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Game Object Variables
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject nextLvlBtn;

    public GameObject loseTextObject;
    public GameObject tryAgainButton;

    //variables for player
    public float speed = 0;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    public int lvlNum = 1;

    private bool lvlFailed = false;
    private bool lvlWin = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        setCountText();
        winTextObject.SetActive(false);
        nextLvlBtn.SetActive(false);
        loseTextObject.SetActive(false);
        tryAgainButton.SetActive(false);
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void setCountText()
    {
        if (lvlFailed == false)
        {
            countText.text = "Count: " + count.ToString();

            if (lvlNum == 1 && count >= 6)
            {
                showWin();
            }
            else if (lvlNum == 2 && count >= 16)
            {
                showWin();
            }

        }
    }

    void FixedUpdate ()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp") && lvlFailed == false)
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
        

    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Spike")
        {
                showLose();
        }
    }

    void showWin()
    {
        lvlWin = true;
        winTextObject.SetActive(true);
        nextLvlBtn.SetActive(true);
        lvlNum++;
    }

    void showLose()
    {
        if (lvlWin == false)
        {
            lvlFailed = true;
            loseTextObject.SetActive(true);
            tryAgainButton.SetActive(true);
        }
        
    }

} 
