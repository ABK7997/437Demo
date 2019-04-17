using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    private GameObject lamp;

    // Start is called before the first frame update
    void Start()
    {
        lamp = GameObject.Find("pSphere3");
    }

    // Update is called once per frame
    void Update()
    {
        Renderer renderer = lamp.GetComponent<Renderer>();
        Material mat = renderer.sharedMaterial;

        if(Input.GetKey(KeyCode.Space) && mat.IsKeywordEnabled("_EMISSION"))
        {
            mat.DisableKeyword("_EMISSION");
            //DynamicGI.SetEmissive(renderer, Color.black);
            //DynamicGI.UpdateEnvironment();
            //DynamicGI.SetEmissive(renderer, Color.black);
        }
        else if (Input.GetKey(KeyCode.Space) && !mat.IsKeywordEnabled("_EMISSION"))
        {
            mat.EnableKeyword("_EMISSION");
            //DynamicGI.SetEmissive(renderer, Color.black);
            //DynamicGI.UpdateEnvironment();
        }
    }
}
