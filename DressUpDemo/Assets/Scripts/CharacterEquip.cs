using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquip : Listener
{
    [Space(10)]
    [Header("====== Bones ======")]
    public Transform[] bonesArray;
    public Transform rootBone;
    public Dictionary<string, Transform> bonesDictionary;



    [Space(10)]
    [Header("====== Attached Cloth ======")]
    public SkinnedMeshRenderer topCloth;
    public SkinnedMeshRenderer bottomCloth;
    public SkinnedMeshRenderer fullBodyCloth;


    // Start is called before the first frame update
    void Start()
    {
        InitializeBoneDictionary();
    }


    private void InitializeBoneDictionary()
    {
        bonesDictionary = new Dictionary<string, Transform>();

        foreach (Transform bone in bonesArray)
        {
            bonesDictionary.Add(bone.name, bone);
        }
    }

    public void EquipClothEvent(GameObject cloth, Cloth_Type cloth_Type)
    {
        ChangeCharacterCloth(cloth, cloth_Type);
    }


    public void ChangeCharacterCloth(GameObject cloth, Cloth_Type cloth_Type)
    {

        switch (cloth_Type)
        {
            case Cloth_Type.TOP:
                DetachClothFromCharacter(topCloth);
                DetachClothFromCharacter(fullBodyCloth);
                AttachClothToCharacter(cloth, out topCloth);
                break;

            case Cloth_Type.BOTTOM:
                DetachClothFromCharacter(bottomCloth);
                DetachClothFromCharacter(fullBodyCloth);
                AttachClothToCharacter(cloth, out bottomCloth);
                break;

            case Cloth_Type.FULLBODY:
                ResetAllClothes();
                AttachClothToCharacter(cloth, out fullBodyCloth);
                break;

            default:
                Debug.LogError("Unknown Cloth Type");
                break;

        }
    }

    private void AttachClothToCharacter(GameObject cloth, out SkinnedMeshRenderer clothSkinnedMesh)
    {
        clothSkinnedMesh = cloth.GetComponentInChildren<SkinnedMeshRenderer>();
        Transform[] newBones = new Transform[clothSkinnedMesh.bones.Length];

        for (int i = 0; i < clothSkinnedMesh.bones.Length; i++)
        {
            if (bonesDictionary.ContainsKey(clothSkinnedMesh.bones[i].name))
            {
                newBones[i] = bonesDictionary[clothSkinnedMesh.bones[i].name];
            }
            else
            {
                Debug.LogError("Character bones dictionary does not contain bone: " + clothSkinnedMesh.bones[i].name);
            }
        }

        clothSkinnedMesh.bones = newBones;
        clothSkinnedMesh.rootBone = rootBone;
        clothSkinnedMesh.transform.SetParent(rootBone.parent);

    }

    private void DetachClothFromCharacter(SkinnedMeshRenderer clothSkinnedMesh)
    {
        if (!clothSkinnedMesh) return;

        Destroy(clothSkinnedMesh.gameObject);
    }

    public void ResetAllClothes()
    {
        DetachClothFromCharacter(fullBodyCloth);
        DetachClothFromCharacter(bottomCloth);
        DetachClothFromCharacter(topCloth);
    }

    public override void AddEventListeners()
    {
        GameBehaviour.Instance.Notifications.AddListener(Game_Events.EquipClothEvent, this);
    }

    public override void RemoveEventListeners()
    {
        GameBehaviour.Instance.Notifications.RemoveListener(Game_Events.EquipClothEvent, this);
    }
}
