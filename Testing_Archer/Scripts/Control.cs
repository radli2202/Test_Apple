using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] Transform ThisTransf;
    [SerializeField] float x, y, z;
    [SerializeField] MobileControl MobContr;

    void Start()
    {
        MobContr = MobContr.GetComponent<MobileControl>();
        ThisTransf = GetComponent<Transform>();        
    }

   
    void Update()
    {
        if (MobContr.Drag)ThisTransf.localRotation = Quaternion.Euler(x, y, 0);

        y = MobContr.Horizontal()*z;
        y = Mathf.Clamp(y, -30, 30);
        x = MobContr.Vertical() * z;
        x = Mathf.Clamp(x, -30, 30);

    }
}
