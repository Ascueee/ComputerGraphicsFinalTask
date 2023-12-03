using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    [SerializeField] Light[] lights;
    [SerializeField] Light mainLight;
    [SerializeField] float timer;
    float resetTimer;
    bool lightOn;
    bool lightOff;
    public bool finalLight;
    // Start is called before the first frame update
    void Start()
    {
        resetTimer = timer;
        lightOn = true;
        mainLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PointLightUpdate();
        MainLightOnOff();
    }

    void PointLightUpdate()
    {
        if (lightOn)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;

                foreach (Light light in lights)
                {
                    light.enabled = true;
                }
            }
            else if (timer <= 0)
            {
                timer = resetTimer;
                lightOn = false;
                lightOff = true;
            }
        }
        else if (lightOff)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;

                foreach (Light light in lights)
                {
                    light.enabled = false;
                }
            }
            else if (timer <= 0)
            {
                timer = resetTimer;
                lightOn = true;
                lightOff = false;
            }
        }
    }

    void MainLightOnOff()
    {
        if (finalLight)
        {
            print("the finall ight is on");
            mainLight.enabled = true;
        }
        else if(!finalLight)
        {
            mainLight.enabled = false;
        }
    }
}
