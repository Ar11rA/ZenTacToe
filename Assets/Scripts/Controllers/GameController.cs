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

	private RestartSignal _restartSignal;

	private ResetSignal _resetSignal;

  public void Initialize()
  {
    _changeSceneSignal += OnSceneChange;
    _areaClickedSignal += OnAreaClicked;
	_resetSignal += OnReset;
  }

  [Inject]
  public GameController(IGameManager gameManager,
  ChangeSceneSignal changeSceneSignal,
  GameStatusChangedSignal gameStatusChangedSignal,
  AreaClickedSignal areaClickedSignal,
  CurrentMarkChangedSignal currentMarkChangedSignal,
	ResetSignal resetSignal,
		RestartSignal restartSignal
	)
  {
    _gameManager = gameManager;
    _changeSceneSignal = changeSceneSignal;
    _areaClickedSignal = areaClickedSignal;
    _gameStatusChangedSignal = gameStatusChangedSignal;
    _currentMarkChangedSignal = currentMarkChangedSignal;
	_resetSignal = resetSignal;
	_restartSignal = restartSignal;
  }

  void OnSceneChange(int sceneId)
  {
    _gameManager.OnSceneChange(sceneId);
  }

  void OnReset() {
	_gameManager.Reset ();
  } 

  public void OnAreaClicked(string clickedIndex)
  {
	_gameManager.OnAreaClicked(clickedIndex);
	bool isGameOver = _gameManager.GetIsGameOver ();
	string gameStatus = _gameManager.GetGameStatus ();
	_gameStatusChangedSignal.Fire(gameStatus, isGameOver);
	
	if (isGameOver) {
	  _restartSignal.Fire ();	
	}
    _currentMarkChangedSignal.Fire(_gameManager.GetCurrentMark());
  }

  public void LateDispose()
  {
    _changeSceneSignal -= OnSceneChange;
    _areaClickedSignal -= OnAreaClicked;
	_resetSignal -= OnReset;
  }
}
