using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixer : MonoBehaviour
{
    // Variables to store RGB components
    private int red = 0;
    private int green = 0;
    private int blue = 0;

    // Reference to the material that represents the mixed color
    public Material mixedColorMaterial;

    // Function to add colors and update the mixed color
    private void UpdateMixedColor()
    {
        mixedColorMaterial.color = new Color(red / 255f, green / 255f, blue / 255f);
    }

    private void Start()
    {
        ResetColor();
    }

    // Function to reset the mixed color to black
    private void ResetColor()
    {
        red = 0;
        green = 0;
        blue = 0;
        UpdateMixedColor();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits a collider in the scene
            if (Physics.Raycast(ray, out hit))
            {
                // Check which game object was hit
                if (hit.collider.CompareTag("RedObject"))
                {
                    red += 10;
                }
                else if (hit.collider.CompareTag("GreenObject"))
                {
                    green += 10;
                }
                else if (hit.collider.CompareTag("BlueObject"))
                {
                    blue += 10;
                }
                else if (hit.collider.CompareTag("ResetButton"))
                {
                    ResetColor();
                }
            }

            // Update the mixed color with the new RGB components
            UpdateMixedColor();
        }
    }
}

