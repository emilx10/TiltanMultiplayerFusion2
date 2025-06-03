using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Fusion;
using TMPro;

public class ReadyCheckManager : MonoBehaviour
{
    public TMP_Text readyCountText;  // UI Text showing how many players ready
    public Button readyToggleButton;

    private NetworkRunner networkRunner;

    private void OnEnable()
    {
        PlayerReady.OnReadyStateChanged += OnPlayerReadyChanged;
    }

    private void OnDisable()
    {
        PlayerReady.OnReadyStateChanged -= OnPlayerReadyChanged;
    }

    private void Start()
    {
        // Updated to use new API
        networkRunner = UnityEngine.Object.FindFirstObjectByType<NetworkRunner>();

        readyToggleButton.onClick.AddListener(OnReadyButtonClicked);

        UpdateReadyCountUI();
    }

    private void OnPlayerReadyChanged(PlayerReady player, bool isReady)
    {
        UpdateReadyCountUI();
    }

    private void UpdateReadyCountUI()
    {
        // Get all PlayerReady instances in the scene
        var players = UnityEngine.Object.FindObjectsByType<PlayerReady>(FindObjectsSortMode.None);
        int readyCount = 0;
        int totalPlayers = players.Length;

        foreach (var player in players)
        {
            if (player.IsReady) readyCount++;
        }

        readyCountText.text = $"Ready Players: {readyCount} / {totalPlayers}";
    }

    private void OnReadyButtonClicked()
    {
        if (networkRunner == null) return;

        PlayerRef localPlayer = networkRunner.LocalPlayer;

        // Replace IsValid with check against default
        if (localPlayer == default)
            return;

        var players = UnityEngine.Object.FindObjectsByType<PlayerReady>(FindObjectsSortMode.None);

        foreach (var player in players)
        {
            if (player.Object.InputAuthority == localPlayer)
            {
                player.RPC_ToggleReady();
                break;
            }
        }
    }

    // Called from FusionCallbacksHandler on player join
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        UpdateReadyCountUI();
    }
}
