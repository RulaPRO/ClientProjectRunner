using System;
using Common;
using UnityEngine;
using View;

public class TileView : MonoBehaviour
{
    public Action OnPlayerEnter;
    public Action OnPlayerExit;
    
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private TriggerZone triggerZone;

    public Transform RespawnPoint => respawnPoint;

    private void OnEnable()
    {
        if (triggerZone != null)
        {
            triggerZone.OnEnter += OnPlayerEnterTileTriggerZone;
            triggerZone.OnExit += OnPlayerExitTileTriggerZone;
        }
    }
        
    private void OnDisable()
    {
        if (triggerZone != null)
        {
            triggerZone.OnEnter -= OnPlayerEnterTileTriggerZone;
            triggerZone.OnExit -= OnPlayerExitTileTriggerZone;
        }
    }
    
    private void OnPlayerEnterTileTriggerZone(string objectTag)
    {
        if (objectTag.Equals("Player"))
        {
            OnPlayerEnter?.Invoke();
        }
    }

    private void OnPlayerExitTileTriggerZone(string objectTag)
    {
        if (objectTag.Equals("Player"))
        {
            OnPlayerExit?.Invoke();
        }
    }
}