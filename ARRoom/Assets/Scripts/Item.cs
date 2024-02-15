using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IItem
{
    [SerializeField] private string nameItem;

    public ItemStatus itemStatus;

    public string NameItem => nameItem;

    public ItemStatus ItemStatus => itemStatus;

    public void SetData(ItemStatus itemStatus)
    {
        this.itemStatus = itemStatus;
    }
}

public interface IItem
{
    string NameItem { get; }
    public ItemStatus ItemStatus { get; }
}
