using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public ETriggerObject TriggerObjectType;
}

public enum ETriggerObject
{
    None = 0,
    Character = 1, 
    Obstacle = 2,
    Circle_Collectible = 21,
    Square_Collectible = 22,
    Hexagon_Collectible = 23,
}
