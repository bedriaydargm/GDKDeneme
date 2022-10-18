using System;
using UnityEngine;
[CreateAssetMenu(fileName = "Obstacle Data", menuName = "Obstacle / New Obstacle")]
public class ObstacleData : ScriptableObject
{
    public ObstacleLevel[] levels;
}

[Serializable]
public struct ObstacleLevel
{
    public Material material;
    public float size;
}