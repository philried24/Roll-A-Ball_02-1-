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
    public TextMeshProUGUI timerText;
    public GameObject winTextObject;
    public GameObject nextLvlBtn;

    public GameObject loseTextObject;
    public GameObject tryAgainButton;

    //variables for player
    public float speed = 0;
    public float timeRemaining;

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
        timeRemaining = 10f;

        setCountText();
        winTextObject.SetActive(false);
        nextLvlBtn.SetActive(false);
        loseTextObject.SetActive(false);
        tryAgainButton.SetActive(false);
        StartCoroutine(UpdateTime());
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
            timeRemaining += 1;
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
            speed = 0;
        }
        
    }


    IEnumerator UpdateTime()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time Left: " + timeRemaining.ToString("F1");
            yield return null;
        }
        showLose();
    }

} 
