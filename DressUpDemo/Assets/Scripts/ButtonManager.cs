using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    Dictionary<Button_Type, List<MenuButton>> _buttonDictionary = new Dictionary<Button_Type, List<MenuButton>>();


    [Header("====== Tab Buttons ======")]
    public List<GameObject> objectsToSwap;
    public Color tabIdleColor;
    public Color tabHoverColor;
    public Color tabActiveColor;
    public MenuButton selectedTab;


    [Header("====== Clothes ======")]
    public Color clothIdleColor;
    public Color clothHoverColor;
    public Color clothActiveColor;
    public MenuButton selectedCloth;


    Color currentIdleColor;
    Color currentHoverColor;
    Color currentActiveColor;
    MenuButton selectedButton;


    public void Subscribe(MenuButton button, Button_Type buttonType)
    {
        if (!_buttonDictionary.ContainsKey(buttonType))
            _buttonDictionary.Add(buttonType, new List<MenuButton>());

        _buttonDictionary[buttonType].Add(button);
    }

    public void OnButtonEnter(MenuButton button, Button_Type buttonType)
    {
        HandleParamsForButtonType(buttonType);

        if (button != selectedButton)
        {
            button.background.color = currentHoverColor;
        }

    }

    public void OnButtonExit(MenuButton button, Button_Type buttonType)
    {
        HandleParamsForButtonType(buttonType);
    }

    public void OnButtonSelected(MenuButton button, Button_Type buttonType)
    {
        if (buttonType == Button_Type.TAB_BUTTON)
        {
            OnTabSelected(button);
        }
        else if (buttonType == Button_Type.CLOTH_BUTTON)
        {
            OnClothSelected(button);
        }

        HandleParamsForButtonType(buttonType);
        selectedButton.background.color = currentActiveColor;
    }


    private void OnTabSelected(MenuButton button)
    {
        selectedTab = button;
        int index = selectedTab.transform.GetSiblingIndex(); // the tab index and correspondent page index must be same

        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }

        ResetPageButtons();
    }

    private void ResetPageButtons()
    {
        selectedCloth = null;
        HandleParamsForButtonType(Button_Type.CLOTH_BUTTON);
    }

    private void OnClothSelected(MenuButton button)
    {
        selectedCloth = button;
        selectedCloth.GetComponent<ClothDragDrop>().OnSelected();
    }

    private void HandleParamsForButtonType(Button_Type buttonType)
    {
        SetVariablesForButtonType(buttonType);
        ResetButtons(buttonType);
    }

    private void SetVariablesForButtonType(Button_Type buttonType)
    {
        if (buttonType == Button_Type.CLOTH_BUTTON)
        {
            currentIdleColor = clothIdleColor;
            currentHoverColor = clothHoverColor;
            currentActiveColor = clothActiveColor;
            selectedButton = selectedCloth;
        }
        else
        {
            currentIdleColor = tabIdleColor;
            currentHoverColor = tabHoverColor;
            currentActiveColor = tabActiveColor;
            selectedButton = selectedTab;
        }
    }

    public void ResetButtons(Button_Type buttonType)
    {
        foreach (MenuButton button in _buttonDictionary[buttonType])
        {
            if (button == selectedButton) { continue; }
            button.background.color = currentIdleColor;
        }
    }

    private void Start()
    {
        SelectDefaultTab();
    }

    private void SelectDefaultTab()
    {
        MenuButton[] buttonArray = _buttonDictionary[Button_Type.TAB_BUTTON].ToArray();
        OnButtonSelected(buttonArray[buttonArray.Length - 1], Button_Type.TAB_BUTTON);
    }
}