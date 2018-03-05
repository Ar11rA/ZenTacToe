using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ClickAreaPresenter : MonoBehaviour
{
  public string currentMark { get; set; }

  public string clickedIndex { get; set; }
  public Text xObj;

  public Text oObj;

  //  public Signal<string> areaClicked = new Signal<string>();

  private bool isClicked = false;

  private bool isGameOver = false;

  private AreaClickedSignal _areaClickedSignal;

  private GameStatusChangedSignal _gameStatusChangedSignal;

  private CurrentMarkChangedSignal _currentMarkChangedSignal;

  [Inject]
  public void Init(AreaClickedSignal areaClickedSignal, 
  GameStatusChangedSignal gameStatusChangedSignal,
  CurrentMarkChangedSignal currentMarkChangedSignal)
  {
    _areaClickedSignal = areaClickedSignal;
    _gameStatusChangedSignal = gameStatusChangedSignal;
    _currentMarkChangedSignal = currentMarkChangedSignal;
  }

  void Start()
  {
    currentMark = GameConstants.DEFAULT_MARK;
    _gameStatusChangedSignal += SetGameOver;
    _currentMarkChangedSignal +=OnCurrentMarkChange;
  }

  public void OnCurrentMarkChange(string currentMark)
  {
    this.currentMark = currentMark;
  }

  public void onClick(string clickedIndex)
  {
    if (isClicked || isGameOver)
      return;

    Text markObject = null;
    switch (currentMark)
    {
      case "x":
        markObject = GameObject.Instantiate(xObj, Vector3.zero, Quaternion.identity);
        break;
      case "o":
        markObject = GameObject.Instantiate(oObj, Vector3.zero, Quaternion.identity);
        break;
    }
    markObject.transform.SetParent(this.transform);
    markObject.rectTransform.localPosition = Vector3.zero;
    _areaClickedSignal.Fire(clickedIndex);
    isClicked = true;
  }

  public void SetGameOver(string gameStatus, bool isGameOverFlag)
  {
    isGameOver = isGameOverFlag;
  }
}
