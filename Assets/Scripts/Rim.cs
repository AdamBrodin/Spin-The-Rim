using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rim : MonoBehaviour
{
    public Text scoreText, speedText;
    public float score, deaccDelay, speed, brakeSpeed, clickAcceleration;
    private int clicks { get; set; }
    public Action<int> rimClicks;
    public Action<float> rimSpeed;

    void Start()
    {
        StartCoroutine(deaccelerate());
    }

    void Update()
    {
        transform.Rotate(0, 0, -1 * (speed * Time.deltaTime));

        score += speed / 1000;
        int rounded = (int)score;
        scoreText.text = rounded.ToString();

        rounded = (int)speed;
        speedText.text = "Speed: " + rounded;
    }

    private void OnMouseDown()
    {
        accelerateSpin();

        clicks++;

        rimClicks?.Invoke(clicks);
    }

    void accelerateSpin()
    {
        speed += clickAcceleration;
    }

    private IEnumerator deaccelerate()
    {
        yield return new WaitForSeconds(deaccDelay);

        if (speed < 0)
        {
            speed = 0;
        } else if(speed > 0)
        {
            speed -= speed / 20;
        } else if(speed > 0 && speed <= 5)
        {
            speed -= brakeSpeed;
        }

        rimSpeed?.Invoke(speed);
        StartCoroutine(deaccelerate());
    }
}
