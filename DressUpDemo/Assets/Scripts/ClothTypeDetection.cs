using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothTypeDetection : MonoBehaviour
{
    private Cloth_Type _clothType;

    public Cloth_Type ClothType
    {
        get
        {
            if (_clothType == Cloth_Type.UNKNOWN) _clothType = DetectClothType();

            return _clothType;
        }
    }


    private Cloth_Type DetectClothType()
    {
        string firstWord = GetFirstWord(name);

        if (Enum.TryParse(firstWord, true, out Cloth_Type type))
        {
            return type;
        }
        else
        {
            Debug.LogError("Cloth Type could not detected");
            return Cloth_Type.UNKNOWN;
        }
    }

    private string GetFirstWord(string input)
    {
        int indexOfSpace = input.IndexOf(' ');
        return indexOfSpace != -1 ? input.Substring(0, indexOfSpace) : input;
    }
}
