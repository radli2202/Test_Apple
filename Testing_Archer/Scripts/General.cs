using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]
public class General : MonoBehaviour
{
    [SerializeField] ArcherFire Arch;
    public static General Gener;
    public int score;
    [SerializeField] int MaxScore,MaxKnife;
    [SerializeField] Text text,maxscoretext,KnifeText;
    [SerializeField] Slider slider;
    [SerializeField] GameObject FullGo, WinGo;

    public UnityEvent <float> unityEvent;

    private void Start()
    {
        Gener = this;
        Arch = Arch.GetComponent<ArcherFire>();
       
        FullGo.SetActive(false); 
        WinGo.SetActive(false);
        maxscoretext.text = MaxScore.ToString();        
        KnifeText.text = MaxKnife.ToString();
        Arch.Knife = MaxKnife;
        Arch.knifs.AddListener((Knife) => KnifeText.text = Knife.ToString());

    }
 

    private void Update()
    {
        text.text = score.ToString();  
       
       
        slider.maxValue = 1;
        slider.value = Arch.Force_curvefloat;
        

        if (endbool) StartCoroutine(End()); 
        if (winbool) WinGo.SetActive(true);
        
    }

   public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(2f);
        if(!winbool) FullGo.SetActive(true);
        yield break;
    }

    bool endbool => Arch.Knife <= 0; 
    bool winbool => score >= MaxScore;

}

