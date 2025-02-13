using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    public Vector2Int size;
    public List<ExitPoint> exits = new();

    [System.Serializable]
    public class ExitPoint
    {
        public Vector2Int position;
        public Direction direction;
    }

    public enum Direction { North, South, East, West }
}
