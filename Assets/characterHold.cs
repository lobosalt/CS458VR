using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterHold : MonoBehaviour
{
    public GameObject slimeCore;
    public GameObject heldToy;
    public GameObject noHold;
    public string Hold = "None";
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pet")
        {
            heldToy = this.gameObject;
            Hold = "Pet";
            transform.position = slimeCore.transform.position;
        }
        else if (collision.gameObject.tag == "Player")
        {
            heldToy = this.gameObject;
            Hold = "Player";
        }
        else
        {
            heldToy = noHold;
            Hold = "None";
        }
    }
}
