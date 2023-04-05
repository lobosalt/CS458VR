using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAI : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float rotSpeed = 100f;
    public float jumpSpeed = 2.0f;
    public float fallMultiplier = 2.5f;

    private bool isWandering = false;
    private bool isRotLeft = false;
    private bool isRotRight = false;
    private bool isWalking = false;
    public bool isPlaying = false;

    public Rigidbody slimeBody;
    // Update is called once per frame
    void Update()
    {
        if (isPlaying == false)
        {
            if (isWandering == false)
            {
                StartCoroutine(Wander());
            }
            if (isRotRight == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            }
            if (isRotLeft == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
            }
            if (isWalking == true)
            {
                slimeBody.AddForce(Vector3.up * jumpSpeed * Time.deltaTime, ForceMode.Impulse);
                transform.position += (transform.forward * moveSpeed * Time.deltaTime);
                slimeBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(2, 4);
        int rotateLorR = Random.Range(1, 3);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 2);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;

        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotLeft = false;
        }
        else
        {
            isRotRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotRight = false;
        }
        isWandering = false;
    }
}
