using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class GameManager : Singleton<GameManager>
{
    public bool IsGamePhaseStarted;

    public bool IsGamePhaseFinished;

    public EPhase PhaseType;
    public Action<EPhase> OnPhaseChanged;

    private void Awake()
    {
        EnterMainMenuPhase();
    }

    public void EnterMainMenuPhase()
    {
        IsGamePhaseStarted = false;
        PhaseType = EPhase.MainMenuPhase;
        OnPhaseChanged?.Invoke(PhaseType);
        Debug.Log("PhaseChangedOnGameManager");
    }
    
    public void EnterGamePhase()
    {
        IsGamePhaseStarted = true;
        PhaseType = EPhase.GamePhase;
        OnPhaseChanged?.Invoke(PhaseType);
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.EnteredGamePhase, this.transform.position);
    }

    public void EnterEndGamePhase()
    {
        IsGamePhaseFinished = true;
        PhaseType = EPhase.EndGamePhase;
        OnPhaseChanged?.Invoke(PhaseType);
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.EnteredEndGamePhase, this.transform.position);

    }
}

public enum EPhase
{
    None = 0,
    MainMenuPhase = 1,
    GamePhase = 2,
    EndGamePhase = 3,
}
