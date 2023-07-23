using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check collision is with object that has the tag "Prop"
        if (collision.gameObject.CompareTag("Prop"))
        {
            Renderer renderer = collision.gameObject.GetComponent<Renderer>();

            // Check if Renderer component is on collided object
            if (renderer != null)
            {
                // Generate a random color
                Color randomColor = new Color(Random.value, Random.value, Random.value);

                // Assign random color to collided object's material (add more script here later)
                renderer.material.color = randomColor;

                // Destroy object so it doesn't change the colors over and over again
                Destroy(gameObject);
            }
        }
    }
}


