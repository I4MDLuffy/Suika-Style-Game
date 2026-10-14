using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool upgraded = false;
    public int level;
    public FlyingKittyScript fks;
    public bool onGround = false;
    public AudioClip mergeSound; // Sound to play upon merging (optional)
    public bool isHeld = false;
    public bool isNext = true;
    private Rigidbody rb;
    private bool isMerged = false;
    private Score score;

    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
        if(upgraded)
        {
            isHeld = false;
            isNext = false;
        }
        rb = GetComponent<Rigidbody>();
        GameObject flyingKittyObject = GameObject.Find("FlyingKitty"); // Replace with the actual name
        if (flyingKittyObject != null)
        {
            fks = flyingKittyObject.GetComponent<FlyingKittyScript>();
        }
        else
        {
            Debug.LogError("FlyingKittyGameObject not found or FlyingKittyScript not attached.");
        }
    }
    void Update()
    {
        if(isNext)
        {
            
        }else if(isHeld)
        {
            gameObject.transform.position = new Vector3(FlyingKittyScript.kittyTransform.position.x, FlyingKittyScript.kittyTransform.position.y -1, FlyingKittyScript.kittyTransform.position.z); 
        }else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = .75f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Char"))
        {
            onGround = true;
        }
        if (!isMerged)
        {
            Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

            if (otherFruit != null && !otherFruit.isMerged && otherFruit.level == level)
            {
                MergeFruits(otherFruit);
            }
        }
    }
    
    void MergeFruits(Fruit otherFruit)
    {
        if(otherFruit.isHeld || isHeld)
        {

        }else
        {
            if(!isMerged)
            {
                otherFruit.isMerged = true;
                isMerged = true;

                // Play merge sound if available
                if (mergeSound != null)
                {
                    AudioSource.PlayClipAtPoint(mergeSound, transform.position);
                }

                // Increase the value of this fruit by merging with another fruit
            
                Vector3 midpoint = (otherFruit.gameObject.transform.position + gameObject.transform.position) / 2f;
                Destroy(otherFruit.gameObject);
                Destroy(gameObject);
                score.AddToScore(level);
                fks.GetComponent<FlyingKittyScript>().UpgradeFruit(level+1, midpoint);
            

                // Update appearance or behavior based on merged value (customize as needed)
                // For example, change the color, scale, or other visual aspects of the fruit

                // Destroy the other fruit after merging
            }
        }

    }
                
}
