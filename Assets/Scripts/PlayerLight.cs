using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{   [SerializeField] private Light innerLight;
    [SerializeField] private Light outerLight;

    [SerializeField] 
    private float _lightIntensity;

    public float LightIntensity 
    { 
        get { return _lightIntensity; } 
        set { UpdateLight(value); } 
    }

    void UpdateLight(float intensity)
    {
        _lightIntensity = intensity;

        outerLight.innerSpotAngle = intensity;
        outerLight.spotAngle = intensity + 15;
        innerLight.innerSpotAngle = intensity - 10;
        innerLight.spotAngle = intensity - 5;
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            LightIntensity = Mathf.Max(0f, LightIntensity + Input.mouseScrollDelta.y * 3f);
        }

        if (GameManager.instance.serialHandler) LightIntensity = GameManager.instance.serialHandler.luminosity;
    }


}
