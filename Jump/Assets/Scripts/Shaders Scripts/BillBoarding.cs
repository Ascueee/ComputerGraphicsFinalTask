using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoarding : MonoBehaviour
{
    Vector3 playerDirection;
    [SerializeField] GameObject playerObj;

   // Update is called once per frame
    void Update()
    {
        playerDirection = playerObj.transform.position;

        transform.rotation = Quaternion.LookRotation(playerDirection);
    }
}
