public interface IGameManager
{
  void OnSceneChange(int sceneId);
  void OnAreaClicked(string clickedIndex);
  string GetGameStatus();
  string GetCurrentMark();
  bool GetIsGameOver();
  void Reset();
}