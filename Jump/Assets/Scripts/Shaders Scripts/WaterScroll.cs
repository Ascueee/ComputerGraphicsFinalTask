using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScroll : MonoBehaviour
{
    [SerializeField] float waterScrollX;
    [SerializeField] float waterScrollY;

    // Update is called once per frame
    void Update()
    {
        float offSetx = Time.time * waterScrollX;
        float offSetY = Time.time * waterScrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offSetx, offSetY);
    }
}
