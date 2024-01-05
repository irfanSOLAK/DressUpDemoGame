using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Button_Type buttonType;
    ButtonManager _buttonManager;
    [HideInInspector] public Image background;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        _buttonManager.OnButtonSelected(this, buttonType);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _buttonManager.OnButtonEnter(this, buttonType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _buttonManager.OnButtonExit(this, buttonType);
    }


    private void Awake()
    {
        SetParameters();
        _buttonManager.Subscribe(this, buttonType);
        AddDragDropFunctionality();
    }

    private void AddDragDropFunctionality()
    {
        if (buttonType != Button_Type.CLOTH_BUTTON) return;

        if (gameObject.GetComponent<ClothDragDrop>() == null)
            gameObject.AddComponent<ClothDragDrop>();

        if (gameObject.GetComponent<ClothTypeDetection>() == null)
            gameObject.AddComponent<ClothTypeDetection>();
    }

    private void SetParameters()
    {
        background = transform.Find("Background").GetComponent<Image>();
        _buttonManager = transform.GetComponentInParent<ButtonManager>();
    }
}
