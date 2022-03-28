using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class ArcherFire : MonoBehaviour 
{
    public AnimationCurve cur;
    public int Knife;
    public float Force_curvefloat;
    [SerializeField] Vector3 vector;
    [SerializeField] Transform PointSpawn, pricel;
    [SerializeField] GameObject Aroww;
    [SerializeField] float force, curvet, curtime;
    int pref_int;




    public static ArcherFire Arch;
    General gen; PoolObjMy pool;
    public UnityEvent <float> knifs;

    void Start()
    {
        gen = General.Gener;
        pool = PoolObjMy.Pref;
        pref_int = pool.AddObject(Aroww);
        Arch = this;
    }

    private void Update()
    {
        curve();
    }


    void curve()
    {
        curvet += Time.deltaTime;
        if (curvet >= curtime) curvet = 0;
        float progress = curvet / curtime;
        Force_curvefloat = cur.Evaluate(progress);
    }

  

    public GameObject GetObj()
    {
        Vector3 Point = PointSpawn.position - pricel.position;
        Quaternion Qu= Quaternion.LookRotation(-Point); 
        GameObject aroww = pool.GetPooledObject(Aroww, PointSpawn.position,Quaternion.Euler(Vector3.zero),null);
        aroww.GetComponent<Rigidbody>().Sleep();
        aroww.GetComponent<Rigidbody>().ResetInertiaTensor();
        aroww.transform.rotation = Qu;
        aroww.GetComponent<Rigidbody>().velocity = -Point * (force*Force_curvefloat);     
        aroww.SetActive(true);
        Knife--;
        knifs.Invoke(Knife);

        return aroww;
    }

    public bool KnifeOn => Knife > 0;




}
