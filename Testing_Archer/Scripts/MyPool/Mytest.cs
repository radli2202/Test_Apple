using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mytest : MonoBehaviour
{
    public GameObject Pref_1, Pref_2,Pref_3;
    int p1, p2,p3;
    public Transform Point;
    PoolObjMy pool;
    public bool rr;

    void Start()
    {
        RadiusStart();
        pool = PoolObjMy.Pref;
        p1 = pool.AddObject(Pref_1);
        p2 = pool.AddObject(Pref_2);
        p3 = pool.AddObject(Pref_3);
    }

    // Update is called once per frame
    void Update()
    {
        rr = tr;
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // GameObject aa = pool.GetPooledObject(p1);
          //  aa.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
          //  GameObject aa = pool.GetPooledObject(p2);
           // aa.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
          //  GameObject aa = pool.GetPooledObject(p3);
          //  aa.SetActive(true);
        }
    }
   public int op;
   [SerializeField] public bool tr => op > 3;

  


    public int numObjects = 10;
    public GameObject prefab;

    void RadiusStart()
    {
        Vector3 center = transform.position;
        for (int i = 0; i < numObjects; i++)
        {
            Vector3 pos = RandomCircle(center, 5.0f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(prefab, pos, rot);
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
