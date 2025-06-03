using Fusion;
using TMPro;
using UnityEngine;

public class NetworkLobbyManager : NetworkBehaviour
{
    [SerializeField] private SimpleLobbyUI lobbyUI;
    [SerializeField] private TMP_Text lobbyNameText;
    public void SetLobbyName(string lobbyName)
    {
        if (lobbyNameText != null)
            lobbyNameText.text = lobbyName;
    }
    public override void Spawned()
    {
        if (lobbyUI == null)
        {
            lobbyUI = FindFirstObjectByType<SimpleLobbyUI>();
            if (lobbyUI == null)
            {
                Debug.LogError("SimpleLobbyUI not found in the scene.");
                return;
            }
        }

        lobbyUI.SetRunner(Runner);
    }
}
