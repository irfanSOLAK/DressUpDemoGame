using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : Listener
{
    [SerializeField] private int _wearAnimationRandomLimit = 6;

    public void EquipClothEvent(GameObject objectGame, Cloth_Type cloth_Type)
    {
        PlayEquipAnimation();
    }

    private void PlayEquipAnimation()
    {
        int randomValue = Random.Range(1, _wearAnimationRandomLimit); // Play the animation not every time, but with probabilities. 
        switch (randomValue)
        {
            case 1:
                PlayAnimatonNamed("Wear1");
                break;
            case 2:
                PlayAnimatonNamed("Wear2");
                break;

            default:
                Debug.Log("There is no animation named Wear" + randomValue);
                break;
        }

    }

    private void PlayAnimatonNamed(string animName)
    {
        GetComponent<Animator>().Rebind();
        GetComponent<Animator>().Play(animName);
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
