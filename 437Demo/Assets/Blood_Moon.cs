using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood_Moon : MonoBehaviour
{

    private LensFlare flare = null;

    // Start is called before the first frame update
    void Start()
    {
        flare = GetComponent<LensFlare>();
    }

    public void FlareColorChanger(Color color)
    {
        if(flare != null)
        {
            flare.color = color;
        }
    }
}
