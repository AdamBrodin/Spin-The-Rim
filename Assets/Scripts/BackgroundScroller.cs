using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    #region Variables
    private float scrollerSpeed, minScrollSpeed = 5f;
    private Vector2 startPos;
    #endregion

    private void Awake()
    {
        Rim rim = FindObjectOfType<Rim>();

        rim.rimSpeed += GetScrollerSpeed;

    }

    private void GetScrollerSpeed(float speed)
    {
        if(speed / 10 >= minScrollSpeed)
        {
            scrollerSpeed += speed / 10;
        }
        else
        {
            scrollerSpeed = minScrollSpeed;
        }
    }

    private void Start()
    {
        startPos = transform.position;

        StartCoroutine(deaccelerate());
    }

    private void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollerSpeed, 13); // Image X size = 13
        transform.position = startPos + Vector2.right * newPos;
        
        print("SPEED: " + scrollerSpeed);
    }

    private IEnumerator deaccelerate()
    {
        scrollerSpeed -= scrollerSpeed / 4;

        yield return new WaitForSeconds(1f);

        StartCoroutine(deaccelerate());
    }

}
