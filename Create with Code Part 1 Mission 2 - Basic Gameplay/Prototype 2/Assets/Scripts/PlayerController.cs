using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public GameObject projectilePrefab;
    public float speed = 10.0f;
    public float xRange = 25;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Keep the player in bounds
        if (transform.position.x < -xRange)
        {
            //Get position and set to minimum of -25 for x position
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); 
        }
        if (transform.position.x > xRange)
        {
            //Get position and set to maximum of 25 for x position
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z); 
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Spawn prefeb at players position with prefabs rotation
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation); 
        }
    }
}
