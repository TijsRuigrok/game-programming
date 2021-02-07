using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    float sendDogCooldown = 2f;
    bool sendDogActive = false;
    float timePassedSinceDogSend;
    float timePassed;

    // Update is called once per frame
    void Update()
    {
        timePassedSinceDogSend = Time.time - timePassed;
        if (timePassedSinceDogSend > sendDogCooldown)
        {
            sendDogActive = false;
        }

        if (!sendDogActive)
        {
            SendDog();
            timePassed = Time.time;
        }  
    }

    private void SendDog()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            sendDogActive = true;
        }
    }
}
