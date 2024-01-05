using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    [Range(-5f, 5f)]
    public float clickRotationSpeed;
    int _rotationFactor = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float rotationSpeed = _rotationFactor * clickRotationSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.Euler(0, rotationSpeed, 0);
        }
    }
}
