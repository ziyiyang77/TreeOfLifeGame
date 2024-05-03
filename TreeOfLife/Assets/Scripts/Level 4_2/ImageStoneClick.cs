using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageStoneClick : MonoBehaviour, IPointerClickHandler
{
   
    public GameObject gemblue;
    public Image paper;
    void Start()
    {
        gameObject.SetActive(false);
        gemblue.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        paper.gameObject.SetActive(false);
        gemblue.SetActive(true);

    }
}
