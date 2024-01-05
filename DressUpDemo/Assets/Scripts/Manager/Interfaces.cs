using UnityEngine;

public interface IListener
{
    void OnEventOccured(Game_Events eventName, GameObject objectGame, Cloth_Type cloth_Type);
}