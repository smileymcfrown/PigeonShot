using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material ColorOutput; // Assign this in the Inspector

    private void OnCollisionEnter(Collision collision)
    {
        // Check collision is with object that has the tag "Prop"
        if (collision.gameObject.CompareTag("Prop"))
        {
            Renderer renderer = collision.gameObject.GetComponent<Renderer>();

            // Check if Renderer component is on collided object
            if (renderer != null)
            {
                // Assign the color from ColorOutput material
                renderer.material = ColorOutput;

                // Destroy object so it doesn't change the colors over and over again
                Destroy(gameObject);
            }
        }
    }
}
