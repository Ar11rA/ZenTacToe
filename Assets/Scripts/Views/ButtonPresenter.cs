using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class ButtonPresenter : MonoBehaviour
{

  private ChangeSceneSignal _changeSceneSignal;
  private ShowTextSignal _showTextSignal;

  [Inject]
  public void Init(ChangeSceneSignal changeSceneSignal, ShowTextSignal showTextSignal)
  {
    _changeSceneSignal = changeSceneSignal;
    _showTextSignal = showTextSignal;
  }

  void Start()
  {
    Button button = GetComponent<Button>() as Button;
    button.onClick.AddListener(OnClick);
  }

  public void OnClick()
  {
    _changeSceneSignal.Fire(1);
    _showTextSignal.Fire("Hello world");
  }
}
