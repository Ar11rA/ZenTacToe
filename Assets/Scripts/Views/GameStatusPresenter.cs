using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameStatusPresenter : MonoBehaviour
{

  public Text gameStatusText;

  private GameStatusChangedSignal _gameStatusChangedSignal;

  [Inject]
  public void Init (GameStatusChangedSignal gameStatusChangedSignal) {
    _gameStatusChangedSignal = gameStatusChangedSignal;
  }


  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  void Start()
  {
      _gameStatusChangedSignal += UpdateScore;
  }

  public void UpdateScore(string status, bool isGameOver)
  {
    gameStatusText.text = status;
  }
}
