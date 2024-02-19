using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class SpawnOptionallyItems: IOptionallyItem
{
    [SerializeField] private Transform posSpawn;
    [SerializeField] private Item item;

    public Transform PosSpawn => posSpawn;

    public Item Item => item;
}

public interface IOptionallyItem
{
    Transform PosSpawn { get; }
    Item Item { get; }
}

public class ItemController : MonoBehaviour
{
    [SerializeField] private List<SpawnAlwaysItem> spawnAlwaysItems;
    [SerializeField] private List<SpawnOptionallyItems> allOptionallyItems;

    [Header("Free data")]
    public List<Transform> freePosSpawn = new List<Transform>();
    public List<Item> freeItems = new List<Item>();

    [Header("Using data")]
    private List<Transform> usingPosSpawn = new List<Transform>();

    private List<Item> firstSpawnningItems = new List<Item>();
    private List<Item> secondSpawningItems = new List<Item>();

    private List<Transform> roomItems = new List<Transform>();

    private float scaleValueForSpawn;

    public void Initialize(float scaleValue)
    {
        this.scaleValueForSpawn = scaleValue;

        for (int i = 0; i < allOptionallyItems.Count; i++)
        {
            freePosSpawn.Add(allOptionallyItems[i].PosSpawn);
        }

        for (int i = 0; i < allOptionallyItems.Count; i++)
        {
            freeItems.Add(allOptionallyItems[i].Item);
        }

        SpawnRoomObjects();
        SpawnFirstItems();
    }


    private void SpawnRoomObjects(Transform transformPref, Transform posSpawn)
    {
        Transform spawnTransform = Instantiate(transformPref);
        spawnTransform.localScale = new Vector3(scaleValueForSpawn, scaleValueForSpawn, scaleValueForSpawn);
        spawnTransform.transform.SetPositionAndRotation(posSpawn.position, posSpawn.rotation);
        spawnTransform.SetParent(posSpawn);
        roomItems.Add(spawnTransform);
    }

    public void SpawnRoomObjects()
    {
        for (int i = 0; i < spawnAlwaysItems.Count; i++)
        {
            SpawnRoomObjects(spawnAlwaysItems[i].Obj, spawnAlwaysItems[i].posSpawn);
        }
    }

    public void SpawnFirstItems()
    {
        for (int i = 0; i < Random.Range(5, freeItems.Count); i++)
        {
            SpawnFirstItem(ItemStatus.Spawn);
        }
    }

    private void SpawnFirstItem(ItemStatus status)
    {
        int indexPosSpawn = Random.Range(0, freeItems.Count);

        if(indexPosSpawn == 0)
        {
            return;
        }

        Item spawningItem = Instantiate(freeItems[indexPosSpawn]);
        spawningItem.transform.localScale = new Vector3(scaleValueForSpawn, scaleValueForSpawn, scaleValueForSpawn);
        spawningItem.transform.SetPositionAndRotation(freePosSpawn[indexPosSpawn].position, freePosSpawn[indexPosSpawn].rotation);
        spawningItem.transform.SetParent(freePosSpawn[indexPosSpawn]);
        spawningItem.SetData(status);

        firstSpawnningItems.Add(spawningItem);
        usingPosSpawn.Add(freePosSpawn[indexPosSpawn]);

        freeItems.Remove(freeItems[indexPosSpawn]);
        freePosSpawn.Remove(freePosSpawn[indexPosSpawn]);
    }


    public void SpawnSecondItems()
    {
        int indexPosSpawn = Random.Range(0, freeItems.Count);
        if(indexPosSpawn == 0)
        {
            return;
        }

        for (int i = 0; i < indexPosSpawn; i++)
        {
            SpawnSecondObject(ItemStatus.Change);
        }
    }

    private void SpawnSecondObject(ItemStatus status)
    {
        if(freeItems.Count <= 0) { return; }
        int indexItem = Random.Range(0, freeItems.Count);
        int indexPosSpawn = Random.Range(0, freeItems.Count);

        Item spawningItem = Instantiate(freeItems[indexItem]);
        spawningItem.transform.localScale = new Vector3(scaleValueForSpawn, scaleValueForSpawn, scaleValueForSpawn);
        spawningItem.transform.SetPositionAndRotation(freePosSpawn[indexPosSpawn].position, freePosSpawn[indexPosSpawn].rotation);
        spawningItem.transform.SetParent(freePosSpawn[indexPosSpawn]);
        spawningItem.SetData(status);

        secondSpawningItems.Add(spawningItem);
        usingPosSpawn.Add(freePosSpawn[indexPosSpawn]);

        freeItems.Remove(freeItems[indexItem]);
        freePosSpawn.Remove(freePosSpawn[indexPosSpawn]);
    }
}

public enum ItemStatus
{
    None, Spawn, Change
}
