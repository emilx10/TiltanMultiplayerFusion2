using Fusion;
using UnityEngine;

public class PlayerReady : NetworkBehaviour
{
    [Networked]
    public bool IsReady { get; set; }

    private bool lastReadyState = false;

    // Event to notify ready state changes
    public delegate void ReadyStateChanged(PlayerReady player, bool isReady);
    public static event ReadyStateChanged OnReadyStateChanged;

    public override void Render()
    {
        // Called every frame on clients, check if ready state changed
        if (lastReadyState != IsReady)
        {
            lastReadyState = IsReady;
            OnReadyStateChanged?.Invoke(this, IsReady);
        }
    }

    // RPC to toggle ready state (called by input authority)
    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void RPC_ToggleReady()
    {
        IsReady = !IsReady;
    }
}
