using System.Collections;
using UnityEngine;

public class Aroww : MonoBehaviour
{
    Rigidbody rb;Transform thisTr;
    [SerializeField] GameObject ApleDecal;   
    [SerializeField] AudioSource AudioFly, AudioApple, AudioWall;
    bool fly;

    General gen;
   
    void Start()
    {
        gen = General.Gener;
        rb = GetComponent<Rigidbody>();
        thisTr = GetComponent<Transform>();
        AudioFly = AudioFly.GetComponent<AudioSource>();
        AudioApple= AudioApple.GetComponent<AudioSource>();
        AudioWall = AudioWall.GetComponent<AudioSource>();
    }
 

    private void OnEnable()
    {
        AudioFly.Play();
        StartCoroutine(offObj());
    }

   IEnumerator offObj()
    {
        yield return new WaitForSeconds(2f);
        if(!fly)gameObject.SetActive(false);
        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish") { fly = true; rb.isKinematic = true; thisTr.parent = collision.transform; AudioWall.Play(); gen.score++; }
        if (collision.gameObject.tag == "Wall") { fly = true; rb.isKinematic = true; thisTr.parent = collision.transform; AudioWall.Play(); gen.score+=10; }
        if (collision.gameObject.tag == "Apple") { Instantiate(ApleDecal, collision.transform.position, Quaternion.identity); Destroy(collision.gameObject); AudioApple.Play(); gen.score += 20; }
    }
}
