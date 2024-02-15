using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnAlwaysItem : IAlwaysItem
{
    [SerializeField] private Transform obj;
    [SerializeField] private Transform posSpawnObj;

    public Transform Obj => obj;
    public Transform posSpawn => posSpawnObj;
} 

interface IAlwaysItem
{
    Transform Obj { get; }
    Transform posSpawn { get; }
}

public class Room : MonoBehaviour
{
    public Vector3 RoomScale { get; private set; } 

    [SerializeField] private ItemController itemController;

    public void Initialize()
    {
        RoomScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        itemController.Initialize(GetMinScaleValue(RoomScale.x, RoomScale.y, RoomScale.z));
    }

    public void Spawn()
    {
        itemController.SpawnSecondItems();
    }

    private float GetMinScaleValue(float a, float b, float c)
    {
        float min = a;

        if (b < min) { min = b; }
        if (c < min) { min = c; }

        return min;
    }
}
