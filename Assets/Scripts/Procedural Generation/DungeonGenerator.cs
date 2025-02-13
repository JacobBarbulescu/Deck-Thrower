using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField] private List<RoomData> roomPrefabs;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private List<TileBase> tileReferences;
    [SerializeField] private int maxRooms = 10;

    private HashSet<Vector2Int> occupiedTiles = new();
    private List<RoomInstance> placedRooms = new();

    private void Start()
    {
        GenerateDungeon();
    }

    private void GenerateDungeon()
    {
        if (roomPrefabs.Count == 0) return;

        // Start with the first room at (0,0)
        RoomData startRoom = roomPrefabs[0];
        PlaceRoom(startRoom, Vector2Int.zero);

        // Generate additional rooms
        for (int i = 1; i < maxRooms; i++)
        {
            TryPlaceNextRoom();
        }

        Debug.Log($"Dungeon Generated with {placedRooms.Count} rooms.");
    }

    private void TryPlaceNextRoom()
    {
        foreach (var placedRoom in placedRooms)
        {
            foreach (var exit in placedRoom.roomData.exits)
            {
                // Find matching room
                RoomData newRoom = roomPrefabs[Random.Range(0, roomPrefabs.Count)];
                RoomData.ExitPoint matchingExit = FindMatchingExit(newRoom, exit.direction);

                if (matchingExit == null) continue;

                // Calculate new position
                Vector2Int newRoomPosition = placedRoom.gridPosition + GetDoorOffset(exit.direction, exit.position, matchingExit.position);

                if (!Overlaps(newRoom, newRoomPosition))
                {
                    PlaceRoom(newRoom, newRoomPosition);
                    return;
                }
            }
        }
    }

    private void PlaceRoom(RoomData roomData, Vector2Int gridPos)
    {
        // Store occupied tiles
        foreach (var tileData in roomData.tiles)
        {
            occupiedTiles.Add(gridPos + tileData.position);
        }

        placedRooms.Add(new RoomInstance(roomData, gridPos));

        // Render room
        foreach (var tileData in roomData.tiles)
        {
            TileBase tile = GetTileByName(tileData.tileName);
            if (tile != null)
            {
                Vector3Int worldPos = new Vector3Int(gridPos.x + tileData.position.x, gridPos.y + tileData.position.y, 0);
                tilemap.SetTile(worldPos, tile);
            }
        }
    }

    private bool Overlaps(RoomData room, Vector2Int pos)
    {
        foreach (var tile in room.tiles)
        {
            if (occupiedTiles.Contains(pos + tile.position))
                return true;
        }
        return false;
    }

    private RoomData.ExitPoint FindMatchingExit(RoomData room, RoomData.Direction direction)
    {
        return room.exits.Find(exit => exit.direction == GetOppositeDirection(direction));
    }

    private Vector2Int GetDoorOffset(RoomData.Direction dir, Vector2Int exitPos, Vector2Int matchingPos)
    {
        switch (dir)
        {
            case RoomData.Direction.North: return new Vector2Int(exitPos.x - matchingPos.x, exitPos.y + 1 - matchingPos.y);
            case RoomData.Direction.South: return new Vector2Int(exitPos.x - matchingPos.x, exitPos.y - 1 - matchingPos.y);
            case RoomData.Direction.East: return new Vector2Int(exitPos.x + 1 - matchingPos.x, exitPos.y - matchingPos.y);
            case RoomData.Direction.West: return new Vector2Int(exitPos.x - 1 - matchingPos.x, exitPos.y - matchingPos.y);
            default: return Vector2Int.zero;
        }
    }

    private RoomData.Direction GetOppositeDirection(RoomData.Direction dir)
    {
        return dir switch
        {
            RoomData.Direction.North => RoomData.Direction.South,
            RoomData.Direction.South => RoomData.Direction.North,
            RoomData.Direction.East => RoomData.Direction.West,
            RoomData.Direction.West => RoomData.Direction.East,
            _ => dir
        };
    }

    private TileBase GetTileByName(string tileName)
    {
        return tileReferences.Find(tile => tile != null && tile.name == tileName);
    }

    private class RoomInstance
    {
        public RoomData roomData;
        public Vector2Int gridPosition;
        public RoomInstance(RoomData room, Vector2Int pos)
        {
            roomData = room;
            gridPosition = pos;
        }
    }
}
