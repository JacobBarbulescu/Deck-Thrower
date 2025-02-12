using UnityEngine;
using System.Collections.Generic;

public class DungeonGenerator : MonoBehaviour
{
    public List<RoomData> roomPool;
    public int dungeonWidth = 5;
    public int dungeonHeight = 5;
    public Grid grid;

    private List<RoomData> generatedRooms = new List<RoomData>();

    void Start()
    {
        if (grid == null)
        {
            Debug.LogError("No Grid GameObject assigned!");
            return;
        }

        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        if (roomPool.Count == 0)
        {
            Debug.LogError("No rooms in the pool!");
            return;
        }

        RoomData firstRoom = Instantiate(roomPool[Random.Range(0, roomPool.Count)], Vector3.zero, Quaternion.identity, grid.transform);
        generatedRooms.Add(firstRoom);

        // Generate the rest of the rooms
        for (int y = 0; y < dungeonHeight; y++)
        {
            for (int x = 0; x < dungeonWidth; x++)
            {
                if (x == 0 && y == 0) continue;

                RoomData newRoom = Instantiate(roomPool[Random.Range(0, roomPool.Count)], Vector3.zero, Quaternion.identity, grid.transform);
                RoomData previousRoom = generatedRooms[generatedRooms.Count - 1];

                //RoomPlacer.PlaceRoomNextTo(previousRoom, newRoom);
                generatedRooms.Add(newRoom);
            }
        }

        Debug.Log("Dungeon Generation Complete!");
    }
}
