using Fusion;
using Fusion.Sockets;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;

public class NetworkGameManager : MonoBehaviour
{
    public NetworkRunner runner;
    public NetworkLobbyManager lobbyManagerPrefab;
    [SerializeField] private TMP_InputField lobbyNameInputField;
    private NetworkLobbyManager lobbyManagerInstance;

    async void Start()
    {
        await StartGame();
    }

    public async Task StartGame()
    {
        runner.ProvideInput = true;

        var result = await runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Host,
            SessionName = "MySession",
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });



        if (result.Ok)
        {
            Debug.Log("Runner started successfully.");

            if (runner.IsServer)
            {
                // Spawn the lobby manager once runner is started & server
                var go = runner.Spawn(lobbyManagerPrefab.gameObject);
                lobbyManagerInstance = go.GetComponent<NetworkLobbyManager>();
            }
        }
        else
        {
            Debug.LogError($"Runner failed to start: {result.ShutdownReason}");
        }
    }
}
