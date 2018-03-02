using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameStatusPresenter : MonoBehaviour
{

  private GameStatusChangedSignal _gameStatusChangedSignal;
  public Text gameStatusText;

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
     Debug.Log ("GAME sta Pres started");
	 gameStatusText = GetComponent<Text> ();
     _gameStatusChangedSignal += UpdateScore;
  }

  public void UpdateScore(string status, bool isGameOver)
  {
    gameStatusText.text = status;
  }
}
