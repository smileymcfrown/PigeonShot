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

    [SerializeField] private GameObject _roofCanvas;
    [SerializeField] private GameObject _flyingBird;
    [SerializeField] private GameObject _staticBird;
    [SerializeField] private PlayerMovement _playerMovement;
    private bool _onRoof;
    private float oldSpeed;
    private bool _feedActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_feedActive && Input.GetKeyDown(KeyCode.Space))
        {
            // Return the player to the original state
            _playerMovement.FlySpeed = oldSpeed;
            _flyingBird.SetActive(true);
            feedCamera.gameObject.SetActive(false);
            playerCamera.enabled = true;
            feedCamera.enabled = false;
            _staticBird.SetActive(false);
            playerBlack.material.color = Color.clear;
            feedBlack.material.color = Color.clear;
            _roofCanvas.SetActive(false);
            _onRoof = false;
            _feedActive = false; // Reset the feed state
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_onRoof && !_feedActive && other.CompareTag("Player"))
        {
            EnterFeedState();
        }
    }

    private void EnterFeedState()
    {
        oldSpeed = _playerMovement.FlySpeed;
        _playerMovement.FlySpeed = 0;
        _flyingBird.SetActive(false);
        feedCamera.gameObject.SetActive(true);
        StartCoroutine(FadeCameras());
        _staticBird.SetActive(true);

        _onRoof = true;
        _feedActive = true;
    }


    IEnumerator FadeCameras()
    {
        float time = 0;
        float duration = 1f;
        if (playerCamera.enabled)
        {
            while (time < (duration))
            {
                playerBlack.material.color = Color.Lerp(Color.clear, Color.black, time / (duration));
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
            _roofCanvas.SetActive(true);
        }
        
    }
}
