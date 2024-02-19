using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoomObject : ScriptableObject, IRoom
{
    [SerializeField] private int roomID;
    [SerializeField] private string nameRoom;
    [SerializeField] private Room room;


    public Room Room => room;
    public string RoomName => nameRoom;
    public int RoomID => roomID;
}

public interface IRoom
{
    int RoomID { get; }
    Room Room { get; }
    string RoomName { get; }
}
