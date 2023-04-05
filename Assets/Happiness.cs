using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happiness : MonoBehaviour
{
    public float HappinessMax;
    public float HappinessRate;
    public float HappinessValue;
    public float HappinessTime;
    public Hunger hunger;

    public bool isHappy;

    public GameObject hapBubble;

    private void Start()
    {
        //Checks if the monster is hungry
        InvokeRepeating("checkIfHungry", 1.0f, HappinessTime);
        InvokeRepeating("checkHappy", 1.0f, 1.0f);
    }
    void checkIfHungry()
    {
        Debug.Log("\nHappiness: " + HappinessValue);
        //If they are hungry decrease happiness
        if (hunger.HungerValue < hunger.HungerMax * 0.2)
        {
            decHappiness();
        }
        //If they aren't hungry increase happiness
        else
        {
            incHappiness();
        }
    }
    void decHappiness()
    {
        HappinessValue -= HappinessRate;
    }
    void incHappiness()
    {
        HappinessValue += HappinessRate;
    }

    void checkHappy()
    {
        if (HappinessValue <= 0)
        {
            HappinessValue = 0;
            isHappy = false;
            hapBubble.SetActive(true);
        }
        else
            hapBubble.SetActive(false);
    }
}
