using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlyingKittyScript : MonoBehaviour
{
    


    public GameObject[] charPrefab; // Prefab of the fruit object
    public Transform dropPoint; // Point from where fruits will be dropped
    static public Transform kittyTransform;
    public float movementSpeed = 5.0f; // Speed of cloud movement
    public float swipeThreshold = 50.0f; // Minimum swipe distance for touch controls
    public float spawnX = 0;
    public float spawnY = 0;
    
    private bool canSwipe = false;

    private Vector2 swipeStartPosition;
    private bool canDrop = true;
    private GameObject nextChar;
    private GameObject heldChar;
    void Start()
    {
        //nextChar = Instantiate(charPrefab[Random.Range(0,5)], new Vector3(spawnX,spawnY,0f), Quaternion.identity);
        nextChar = Instantiate(charPrefab[Random.Range(0,5)], new Vector3(1.2f,6.25f,0f), Quaternion.identity);
        heldChar = Instantiate(charPrefab[Random.Range(0,5)], dropPoint.position, Quaternion.identity);
        heldChar.GetComponent<Fruit>().isHeld = true;
        heldChar.GetComponent<Fruit>().isNext = false;
    }

    void Update()
    {

        kittyTransform = transform;
        // Keyboard Controls (for Windows)
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * movementSpeed * Time.deltaTime);

        // Touch Controls (for Android)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                swipeStartPosition = touch.position;
                canSwipe = true;
            }
            else if (touch.phase == TouchPhase.Moved && canSwipe)
            {
                float swipeDistance = touch.position.x - swipeStartPosition.x;

                if (Mathf.Abs(swipeDistance) >= swipeThreshold)
                {
                    float swipeDirection = Mathf.Sign(swipeDistance);
                    transform.Translate(Vector3.right * swipeDirection * movementSpeed * Time.deltaTime);
                    canSwipe = false;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                DropChar(); // Drop fruit on touch release
            }
        }

        // Clamping the cloud's movement within the screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, -5.3f, 1.75f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Dropping fruits (Spacebar for Windows)
        if ((canDrop == true) && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ActionCooldown());
        }
    }
    IEnumerator ChangeheldChar()
    {
        yield return new WaitForSeconds(.75f);

        // After waiting for the specified time, change the variable
        heldChar.GetComponent<Fruit>().isNext = false;
        heldChar.GetComponent<Fruit>().isHeld = true;
    }
    IEnumerator ActionCooldown()
    {
        // Perform your action here
        DropChar();

        // Disable the ability to perform the action temporarily
        canDrop = false;

        // Wait for the cooldown duration
        yield return new WaitForSeconds(.85f);

        // Enable the ability to perform the action again after cooldown
        canDrop = true;
    }
    IEnumerator SpawnNextChar()
    {
        yield return new WaitForSeconds(.8f);

        // After waiting for the specified time, change the variable
        nextChar = Instantiate(charPrefab[Random.Range(0,5)], new Vector3(1.2f,6.25f,0f), Quaternion.identity);
        //nextChar = Instantiate(charPrefab[4], new Vector3(3.5f,5.5f,0f), Quaternion.identity);
    }
    void DropChar()
    {
        
        heldChar.GetComponent<Fruit>().isHeld = false;
        heldChar.GetComponent<Fruit>().isNext = false;
        heldChar = nextChar;
        StartCoroutine(ChangeheldChar());
        StartCoroutine(SpawnNextChar());
    }
    public void UpgradeFruit(int level, Vector3 pos)
    {
        GameObject upgradedChar = Instantiate(charPrefab[level], pos , Quaternion.identity);
        upgradedChar.GetComponent<Fruit>().upgraded = true;
    }
}
    

