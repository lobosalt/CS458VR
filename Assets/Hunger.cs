using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    public float HungerMax;
    public float HungerValue;
    public float HungerRate;
    public float HungerTime;
    public float HungerStart;

    public bool isHungry;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("decHunger", HungerStart, HungerTime);
    }

    //Decrease hunger to a minimum of 0
    void decHunger()
    {
        HungerValue -= HungerRate;
        if (HungerValue < 0)
            HungerValue = 0;
        Debug.Log("\nHunger: " + HungerValue);
    }

    //Allows feeding of the monster
    void eatFood(Collision cObject)
    {
        //If fed a watermelon increase hunger by 100
        if (cObject.gameObject.name == "Watermelon")
        {
            if (HungerValue + 100 <= HungerMax)
            {
                HungerValue += 100;
                Destroy(cObject.gameObject);
            }
            else if (HungerValue + 100 > HungerMax)
            {
                HungerValue = HungerMax;
                Destroy(cObject.gameObject);
            }
        }
        //If fed a cherry increase hunger by 25
        if (cObject.gameObject.name == "Cherry")
        {
            if(HungerValue + 25 <= HungerMax)
            {
                HungerValue += 25;
                Destroy(cObject.gameObject);
            }
            else if(HungerValue + 25 > HungerMax)
            {
                HungerValue = HungerMax;
                Destroy(cObject.gameObject);
            }
        }
    }

    //Check if the item we are trying to feed our monster is food
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            eatFood(collision);
        }
    }

    private void checkHunger()
    {
        if(HungerValue < HungerMax * 0.2)
        {
            isHungry = true;
        }
    }
}
