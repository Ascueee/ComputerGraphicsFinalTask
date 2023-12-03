using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Vars")]
    [SerializeField] Transform[] cameraPoints;
    [SerializeField] float lerpTime;
    [SerializeField] int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeCamPosition(int ind)
    {
        transform.position = cameraPoints[ind].position;
    }


    public void IncrementIndex()
    {
        index++;
        ChangeCamPosition(index);
    }

    public void DecrementIndex()
    {
        index--;
        ChangeCamPosition(index);
    }
}
