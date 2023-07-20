using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godScript : MonoBehaviour
{

    public GameObject player;
    public GameObject finishDoor;
    public GameObject keyicon;
    public GameObject key;
    public GameObject camera;

    public bool hasKey = false;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private Vector3 distanceFromCamera;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasKey)
        {
            /*
            distanceFromCamera = key.transform.position - camera.transform.position;

            targetPosition = camera.transform.position + new Vector3(1f, -0.5f, 1f);
            targetRotation = camera.transform.rotation * Quaternion.Euler(180f, 30f, -90f);

            // Calculate the target position based on the camera's position and distanceFromCamera
            targetPosition = camera.transform.position - camera.transform.forward * distanceFromCamera.magnitude;

            // Update the target rotation based on the camera's rotation
            targetRotation = Quaternion.LookRotation(camera.transform.forward, camera.transform.up);

            // Calculate the interpolation factor based on the desired speed (e.g., 5f)
            float t = Time.deltaTime * 20f;

            // Smoothly move the key towards the target position
            key.transform.position = Vector3.Lerp(key.transform.position, targetPosition, t);

            // Smoothly rotate the key towards the target rotation
            key.transform.rotation = Quaternion.Lerp(key.transform.rotation, targetRotation, t);
            */
            // Calculate the interpolation factor based on the desired speed (e.g., 5f)
            //float t = Time.deltaTime * 20f;
            //key.transform.position = camera.transform.position;
            //key.transform.position = Vector3.Lerp(key.transform.position, camera.transform.position + new Vector3(1, -0.5f, 1), t);
            //key.transform.localRotation = camera.transform.rotation;
            //key.transform.localRotation = Quaternion.Lerp(key.transform.localRotation, player.transform.rotation * Quaternion.Euler(180, 30, -90), t);
            //key.transform.Translate(1, -0.5f, 1);
            //key.transform.Rotate(180, 30, -90);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("finishDoor"))
        {
            Debug.Log("You win!");
        }
        if (collision.gameObject.CompareTag("key"))
        {
            Debug.Log("got the key");
            hasKey = true;
            //GameObject.FindGameObjectWithTag("key").SetActive(false);
            keyicon.SetActive(true);
            // Disable the key's renderer
            //key.GetComponent<Renderer>().enabled = false;

            // Disable the key's collider
            key.GetComponent<Collider>().enabled = false;

            // Make the key a child of the player
            key.transform.SetParent(camera.transform);

            // Adjust the position and rotation of the key
            key.transform.localPosition = new Vector3(1f, -0.5f, 1f);
            key.transform.localRotation = Quaternion.Euler(180, 30, -90);

        }
    }

}
