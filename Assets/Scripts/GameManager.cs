using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer cameraBlack;
        
    // Start is called before the first frame update
    void Start()
    {
        
        cameraBlack.material.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
