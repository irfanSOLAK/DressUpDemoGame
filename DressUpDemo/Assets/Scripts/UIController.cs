using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void ResetClothes()
    {
        GameBehaviour.Instance.Sophie.GetComponent<CharacterEquip>().ResetAllClothes();
    }
}
