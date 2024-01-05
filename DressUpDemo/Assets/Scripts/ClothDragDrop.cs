using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothDragDrop : MonoBehaviour
{
    public bool isDragging;

    [Space(10)]
    [Header("====== Cloth UI Image ======")]
    public GameObject clothImage;
    RectTransform _clothImageRect;
    GameObject _clothImageClone;


    [Space(10)]
    [Header("====== Cloth 3D Model ======")]
    public GameObject clothModel;
    public float ClothModelDistanceOffset = 0.1f;
    string _clothModelName;                              // Model Name, Button name and Button Folder name are the same
    GameObject _clothModelClone;


    // Start is called before the first frame update
    void Awake()
    {
        isDragging = false;
        InitializeClothImage();
        InitializeClothModel();
    }

    private void InitializeClothImage()
    {
        clothImage = transform.Find("Cloth").gameObject;
        _clothImageRect = clothImage.GetComponent<RectTransform>();
    }
    private void InitializeClothModel()
    {
        _clothModelName = name;
        clothModel = Resources.Load<GameObject>("Models/Clothes/" + _clothModelName + "/" + _clothModelName);
    }

    public void OnSelected()
    {
        isDragging = true;
        CreateCloneImage();
        CreateCloneModel();
        StartCoroutine(DragCoroutine());
    }

    private void CreateCloneImage()
    {
        _clothImageClone = Instantiate(clothImage, clothImage.transform.position, clothImage.transform.rotation, transform);
        _clothImageClone.transform.SetParent(GameObject.FindWithTag("RightMenu").transform);
    }

    private void CreateCloneModel()
    {
        _clothModelClone = Instantiate(clothModel);
        _clothModelClone.GetComponentInChildren<SkinnedMeshRenderer>().transform.gameObject.layer = LayerMask.NameToLayer("Cloth Model");
    }

    IEnumerator DragCoroutine()
    {
        while (isDragging)
        {

            if (Input.GetMouseButton(0))
            {
                DragClothImage();
                DragClothModel();

            }
            if (Input.GetMouseButtonUp(0))
            {
                OnUnSelected();
            }

            yield return null;
        }
    }

    public void DragClothImage()
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(_clothImageRect, Input.mousePosition, Camera.main, out Vector3 worldPoint);
        _clothImageClone.GetComponent<RectTransform>().position = worldPoint;
    }

    private void DragClothModel()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = GameBehaviour.Instance.Sophie.transform.position.z - ClothModelDistanceOffset;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Quaternion sophieRotation = GameBehaviour.Instance.Sophie.transform.rotation;

        _clothModelClone.transform.position = worldPosition;
        _clothModelClone.transform.rotation = sophieRotation;
    }

    public void OnUnSelected()
    {
        isDragging = false;

        UnSelectedClothImage();
        UnSelectedClothModel();
    }

    private void UnSelectedClothImage()
    {
        Destroy(_clothImageClone);
    }

    private void UnSelectedClothModel()
    {
        GameBehaviour.Instance.Notifications.PostNotification(Game_Events.EquipClothEvent, _clothModelClone, GetComponent<ClothTypeDetection>().ClothType);
        Destroy(_clothModelClone);
    }
}
