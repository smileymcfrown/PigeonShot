using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Player;
    public GameObject Shit;
    public float FlySpeed = 5;
    public float YawAmount = 120;

    private float Yaw;
    // Start is called before the first frame update
    void Start()
    {
        Player = this;
    }

    // Update is called once per frame
    void Update()
    {
        //move forward
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        //inputs
        //float horizontalInput = Input.GetAxis("Vertical");
        //float verticalInput = Input.GetAxis("Horizontal");

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //yaw, pitch, roll
        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        //apply the rotation
        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Shit, transform.position, Quaternion.identity);
        }
    }
}
