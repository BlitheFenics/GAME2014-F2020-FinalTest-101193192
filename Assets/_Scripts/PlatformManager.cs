using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    float moveSpeed = 0.1f, scaleRate = 1.5f;
    bool floatUp = true, scaleDown = true;
    public bool movePlatform, shrink = false;

    public PlayerBehaviour player;

    private void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the platform up and down
        if (movePlatform == true)
        {
            if (transform.position.y > 0.1f)
            {
                floatUp = false;
            }
            if (transform.position.y < -0.1f)
            {
                floatUp = true;
            }

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
        if (shrink == true)
        {
           
            if (transform.localScale.x > 0f && transform.localScale.y > 0f)
            {
                scaleDown = true;
            }

            if (scaleDown)
            {
                Vector2 scale = new Vector2(transform.localScale.x - scaleRate * Time.deltaTime, transform.localScale.y - scaleRate * Time.deltaTime);
                transform.localScale = scale;
            }

            if (transform.localScale.x < 0.1f && transform.localScale.y < 0.1f)
            {
                scaleDown = false;

            }
        }

        if (shrink == false)
        {
            if (transform.localScale.x > 5f && transform.localScale.y > 5f)
            {
                scaleDown = false;
            }

            if (scaleDown)
            {
                Vector2 scale = new Vector2(transform.localScale.x + scaleRate * Time.deltaTime, transform.localScale.y + scaleRate * Time.deltaTime);
                transform.localScale = scale;
            }

            if (transform.localScale.x < 5f && transform.localScale.y < 5f)
            {
                scaleDown = true;
            }
        }
    }
}
