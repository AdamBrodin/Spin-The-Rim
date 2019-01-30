using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour
{
    private int successfulClicks;

    private void Awake()
    {
        Rim rim = FindObjectOfType<Rim>();

        rim.rimClicks += getClicks;
    }

    private void getClicks(int clicks)
    {
        successfulClicks = clicks;
    }

    private void Update()
    {
        statusCheck();
    }

    private void statusCheck()
    {
        switch(successfulClicks)
        {
            case 10:
                print("10 clicks");
                break;
            case 25:
                print("25 clicks");
                break;
        }
    }
}
