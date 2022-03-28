using System.Collections;
using UnityEngine;

public class RandomColor : MonoBehaviour
{

    Camera camera;
   
    void Start()
    {
        camera = GetComponent<Camera>();
        camera.backgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        StartCoroutine(Wait());

    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
       // camera.backgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        Color color_1= new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        camera.backgroundColor = Color.Lerp(camera.backgroundColor, color_1, Mathf.PingPong(Time.time,3));

        StartCoroutine(Wait());
        yield break;
    }
}
