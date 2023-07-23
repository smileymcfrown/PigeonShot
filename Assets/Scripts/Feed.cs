using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Feed : MonoBehaviour
{
    public Camera playerCamera;
    public MeshRenderer playerBlack;
    public Camera feedCamera;
    public MeshRenderer feedBlack;

    public PlayerMovement playerMovement;
    private bool onRoof;
    private float oldSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!onRoof)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                oldSpeed = playerMovement.FlySpeed;
                playerMovement.FlySpeed = 0;
                feedCamera.gameObject.SetActive(true);
                StartCoroutine(FadeCameras());
            }

            onRoof = true;
        }
    }

    IEnumerator FadeCameras()
    {
        float time = 0;
        float duration = 1f;
        if (playerCamera.enabled)
        {
            while (time < (duration*2))
            {
                playerBlack.material.color = Color.Lerp(Color.clear, Color.black, time / (duration*2));
                time += Time.deltaTime;
                yield return null;
            }

            playerCamera.enabled = false;
            feedCamera.enabled = true;
            time = 0f;
            
            while (time < duration)
            {
                feedBlack.material.color = Color.Lerp(Color.black, Color.clear, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
        }
        
    }
}
