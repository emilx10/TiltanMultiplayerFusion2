using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;

public class LobbyManager : MonoBehaviour, INetworkRunnerCallbacks
{
   [SerializeField] NetworkRunner networkRunner;

   private void Start()
   {
      networkRunner.AddCallbacks(this);
   }

   public void StartSession()
   {
      networkRunner.StartGame(new StartGameArgs()
      {
         GameMode = GameMode.Shared,
         SessionName = "OurGameID",
         OnGameStarted = OnGameStarted
      });
   }
   
   private void OnGameStarted(NetworkRunner obj)
   { 
      Debug.Log("Game Started");
   }

   public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
   {
      
   }

   public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
   {
   }

   void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player)
   {
   }

   public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
   {
   }

   public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
   {
   }

   public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
   {
   }

   public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
   {
   }

   public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
   {
   }

   public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
   {
   }

   public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
   {
   }

   public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
   {
   }

   public void OnInput(NetworkRunner runner, NetworkInput input)
   {
   }

   public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
   {
   }

   public void OnConnectedToServer(NetworkRunner runner)
   {
   }

   public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
   {
   }

   public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
   {
   }

   public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
   {
   }

   public void OnSceneLoadDone(NetworkRunner runner)
   {
   }

   public void OnSceneLoadStart(NetworkRunner runner)
   {
   }
   
   
   // public async void StartSession()
   // {
   //    StartGameResult resTask = await networkRunner.StartGame(new StartGameArgs()
   //    {
   //       GameMode = GameMode.Shared,
   //       SessionName = "OurGameID",
   //       OnGameStarted = OnGameStarted
   //    });
   //
   //    if (resTask.Ok)
   //    {
   //       OnGameStarted(networkRunner);
   //    }
   //    else
   //    {
   //       Debug.LogError($"Game failed to start because {resTask.ErrorMessage}");
   //    }
   // }
   //
   // private void OnGameStarted(NetworkRunner obj)
   // {
   //    Debug.Log("Game Started");;
   // }
}
