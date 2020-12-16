using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            
            if (transform.position.y > bobUp)
            {
                floatUp = false;
            }
            if (transform.position.y < bobDown)
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
        if (scalePlatform == true)
        {
            
            if (shrink == true)
            {
                ASshrinking.clip = growing;
                ASshrinking.Play();

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
                ASgrowing.clip = shrinking;
                ASgrowing.Play();

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
}
