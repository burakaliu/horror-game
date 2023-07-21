using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAudioController : MonoBehaviour
{

    public AudioSource footstepSounds;
    public AudioSource jumpSound;
    public float speedMultiplier = 1.5f; // Adjust this value to change the speed multiplier
    public Transform transform;

    public Slider staminaSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && staminaSlider.value >= 5)
        {
            Debug.Log("shift pressed");
            speedMultiplier = 2.5f;
        }
        else
        {
            speedMultiplier = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //jumpSound.Play();
        }

        footstepSounds.pitch = speedMultiplier;

        // Check if any movement keys are pressed (W, A, S, or D)
        bool isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (isWalking && transform.position.y == 1)
        {
            if (!footstepSounds.isPlaying)
            {
                footstepSounds.Play();
            }
        }
        else
        {
            footstepSounds.Stop();
        }
    }
}
