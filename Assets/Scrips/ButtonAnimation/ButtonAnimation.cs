using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public RectTransform Button;

    // Start is called before the first frame update
    void Start()
    {
        Button.GetComponent<Animator>().Play("ButtonAnimation_Idle_Real");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ButtonAnimation
    public void OnPointerEnter(PointerEventData eventData)
    {
        Button.GetComponent<Animator>().Play("ButtonAnimation");
    }

    public void OnPointerExit(PointerEventData evenData)
    {
        Button.GetComponent<Animator>().Play("ButtonAnimation_Idle");
    }
}
