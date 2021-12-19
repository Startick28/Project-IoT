using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWallInvisibility : MonoBehaviour
{   
    Renderer rendererer;

    float min = 0.2f;
    float max = 2f;
    float cool = 90f;

    void Start()
    {
        rendererer = gameObject.GetComponent<Renderer>();
    }

    
    void Update()
    {
        Vector2 CutoutPos = Camera.main.WorldToViewportPoint(GameManager.instance.GetPlayerPosition());
        CutoutPos.y /= (Screen.width/Screen.height);

        Vector3 offset = GameManager.instance.GetPlayerPosition() - transform.position;
        Material[] materials = rendererer.materials;

        float tmp = GameManager.instance.GetPlayerLightIntensity()/cool;

        float cutout = Mathf.Lerp(min,max, tmp*tmp);

        for (int m = 0; m < materials.Length; m++)
        {
            materials[m].SetVector("_CutoutPosition", CutoutPos);
            materials[m].SetFloat("_CutoutSize", cutout);
            materials[m].SetFloat("_FallofSize", cutout);
        }
    }
    

}
