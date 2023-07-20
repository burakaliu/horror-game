using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAudioController : MonoBehaviour
{

    public AudioSource footstepSounds;
    public float speedMultiplier = 1.5f; // Adjust this value to change the speed multiplier

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("shift pressed");
            speedMultiplier = 2.5f;
        }
        else
        {
            speedMultiplier = 1f;
        }

        footstepSounds.pitch = speedMultiplier;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            footstepSounds.Play();
        }
    }
}
