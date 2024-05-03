using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageStoneClick : MonoBehaviour, IPointerClickHandler
{
   
    public Image gemblue;
    void Start()
    {
        gemblue.gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Image±»µã»÷ÁË£¡");
        gameObject.SetActive(false);
        gemblue.gameObject.SetActive(true);

    }
}
