using Fusion;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
   [SerializeField] NetworkRunner networkRunner;
   
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
      Debug.Log("Game Started");;
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
