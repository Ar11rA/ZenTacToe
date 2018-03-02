using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : IInitializable, ILateDisposable
{

  private ChangeSceneSignal _changeSceneSignal;

  private GameStatusChangedSignal _gameStatusChangedSignal;

  private AreaClickedSignal _areaClickedSignal;

  private CurrentMarkChangedSignal _currentMarkChangedSignal;

  private IGameManager _gameManager;

  public void Initialize()
  {
    _changeSceneSignal += OnSceneChange;
    _areaClickedSignal += OnAreaClicked;
  }

  [Inject]
  public GameController(IGameManager gameManager,
  ChangeSceneSignal changeSceneSignal,
  GameStatusChangedSignal gameStatusChangedSignal,
  AreaClickedSignal areaClickedSignal,
  CurrentMarkChangedSignal currentMarkChangedSignal)
  {
    _gameManager = gameManager;
    _changeSceneSignal = changeSceneSignal;
    _areaClickedSignal = areaClickedSignal;
    _gameStatusChangedSignal = gameStatusChangedSignal;
    _currentMarkChangedSignal = currentMarkChangedSignal;
  }

  void OnSceneChange(int sceneId)
  {
    _gameManager.OnSceneChange(sceneId);
  }

  public void OnAreaClicked(string clickedIndex)
  {
    _gameManager.OnAreaClicked(clickedIndex);
    _gameStatusChangedSignal.Fire(_gameManager.GetGameStatus(), _gameManager.GetIsGameOver());
    _currentMarkChangedSignal.Fire(_gameManager.GetCurrentMark());
  }

  public void LateDispose()
  {
    _changeSceneSignal -= OnSceneChange;
    _areaClickedSignal -= OnAreaClicked;

  }
}
