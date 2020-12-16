using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Source File Name: PlatformManager
 * Author's Name: Phoenix Makins
 * Student Number: 101193192
 * Date Last Modified: 2020-12-16
 * Program Description: Allows a platform to bob up and down, the platform will shrink when the player is colliding with it and grow back to it's original size when the player isn't colliding with it. It will also play sound effects when growing or shrinking.
 * Revision History: created it, Added bobbing, added shrinking, added growing, added sounds
 */

public class PlatformManager : MonoBehaviour
{
    float moveSpeed = 0.1f, scaleRate = 1.5f;
    public float bobUp, bobDown;
    bool floatUp = true, scaleDown = true;
    public bool movePlatform, scalePlatform, shrink = false;

    public PlayerBehaviour player;

    public AudioSource ASgrowing, ASshrinking;
    public AudioClip growing;
    public AudioClip shrinking;

    // Initializes at the start of the scene
    private void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        ASgrowing = gameObject.AddComponent<AudioSource>();
        ASshrinking = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the platform up and down
        if (movePlatform == true)
        {
            // Set the range for the platform bobbing
            if (transform.position.y > bobUp)
            {
                floatUp = false;
            }
            if (transform.position.y < bobDown)
            {
                floatUp = true;
            }

            // Bob the platforms over a set timeframe
            if (floatUp)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            }
        }

        // Scales the platforms size
        if (scalePlatform == true)
        {
            
            if (shrink == true)
            {
                // Plays the growing sound effect
                ASshrinking.clip = growing;
                ASshrinking.Play();

                // Shrinks only if the platforms scale is greater than 0 on both x and y
                if (transform.localScale.x > 0f && transform.localScale.y > 0f)
                {
                    scaleDown = true;
                }

                // Scales down the platform over a set timeframe
                if (scaleDown)
                {
                    Vector2 scale = new Vector2(transform.localScale.x - scaleRate * Time.deltaTime, transform.localScale.y - scaleRate * Time.deltaTime);
                    transform.localScale = scale;
                }
                
                // Stops shrinking the platform when it's scale is less than 0.1 on the x and y
                if (transform.localScale.x < 0.1f && transform.localScale.y < 0.1f)
                {
                    scaleDown = false;
                }
            }
            
            if (shrink == false)
            {
                // Plays the shrinking sound effect
                ASgrowing.clip = shrinking;
                ASgrowing.Play();

                // Grows only if the platforms scale is less than 5 on both the x and y
                if (transform.localScale.x > 5f && transform.localScale.y > 5f)
                {
                    scaleDown = false;
                }

                // Scales up the platform over a set timeframe
                if (scaleDown)
                {
                    Vector2 scale = new Vector2(transform.localScale.x + scaleRate * Time.deltaTime, transform.localScale.y + scaleRate * Time.deltaTime);
                    transform.localScale = scale;
                }

                // Stops growing the platform when it's scale it greater than 5 on both the x and y
                if (transform.localScale.x < 5f && transform.localScale.y < 5f)
                {
                    scaleDown = true;
                }
            }
        }
    }
}
