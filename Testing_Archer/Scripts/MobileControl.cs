using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileControl : MonoBehaviour,IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public Image BG_Image;
    public Image Jostic;
    Vector2 _inputVector;
    ArcherFire archer;
    public bool Drag=true;


    void Start()
    {
        archer = ArcherFire.Arch;
        BG_Image = GetComponent<Image>();
        Jostic = transform.GetChild(0).GetComponent<Image>();

    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
  
        OnDrag(ped);
      
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        _inputVector = Vector2.zero;
        Jostic.rectTransform.anchoredPosition = Vector2.zero;

        Push();


    }
    public virtual void OnDrag(PointerEventData ped)
    {

        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BG_Image.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / BG_Image.rectTransform.sizeDelta.x);
            pos.y = (pos.y / BG_Image.rectTransform.sizeDelta.x);

            _inputVector = new Vector2(pos.x, pos.y);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;
            Jostic.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (BG_Image.rectTransform.sizeDelta.x / 2), _inputVector.y * (BG_Image.rectTransform.sizeDelta.y / 2));

        }

     
    }




    public float Horizontal()
    {
        if (_inputVector.x != 0) return _inputVector.x;
        else return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (_inputVector.y != 0) return _inputVector.y;
        else return Input.GetAxis("Vertical");
    }

    void Push()
    {
        if(archer.KnifeOn)archer.GetObj();

        Drag = false;
        StartCoroutine(OnBoolDrag());

    }

    IEnumerator OnBoolDrag()
    {
        yield return new WaitForSeconds(1f);
        Drag = true;
        yield break;
    }
   
}
