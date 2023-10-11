using FMODUnity;
using UnityEngine;

public class FMODEvents : Singleton< FMODEvents>
{
    [field: Header("EatCollectible SFX")]
    [field: SerializeField] public EventReference CollectibleCollectedSound { get; private set; }
    
    [field: Header("GamePhase SFX")]
    [field: SerializeField] public EventReference EnteredGamePhase { get; private set; }
    
    [field: Header("EndGamePhase SFX")]
    [field: SerializeField] public EventReference EnteredEndGamePhase { get; private set; }
}
