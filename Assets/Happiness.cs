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

    private void Start()
    {
        //Checks if the monster is hungry
        InvokeRepeating("checkIfHungry", 1.0f, HappinessTime);
    }
    void checkIfHungry()
    {
        Debug.Log("\nHappiness: " + HappinessValue);
        //If they are hungry decrease happiness
        if (hunger.HungerValue <= 0)
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
}
