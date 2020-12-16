using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    float moveSpeed = 0.1f;
    bool floatUp = true;
    public bool movePlatform;

    // Update is called once per frame
    void Update()
    {
        // Moves the platform left and right based on a range
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
    }
}
