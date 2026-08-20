using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionCamera : MonoBehaviour
{
    public Camera thisCamra;
    void Start()
    {
        thisCamra.cullingMask = 1<< 6;
    }


}
