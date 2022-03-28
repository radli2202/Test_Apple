using System.Collections.Generic;
using UnityEngine;


public class RotateCircle : MonoBehaviour
{
    [SerializeField] float Rotate,Radius;
    [SerializeField] int numApple = 10;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform pointcentr;
    [SerializeField] List<GameObject> Apple;
    Transform thisTr;
    void Start()
    {
        RadiusStart();
        pointcentr = pointcentr.GetComponent<Transform>();
        thisTr = GetComponent<Transform>();
    }

   
    void Update()
    {
        thisTr.Rotate(new Vector3(0,0, Rotate)* Time.deltaTime);
    }

    void RadiusStart()
    {
        Vector3 center = pointcentr.position;
        for (int i = 0; i < numApple; i++)
        {
            Vector3 pos = RandomCircle(center, Radius);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Quaternion looc = Quaternion.LookRotation(pos-center);
            GameObject aple= Instantiate(prefab, pos, looc) as GameObject;
            aple.transform.parent = gameObject.transform;
            Apple.Add(aple);
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
