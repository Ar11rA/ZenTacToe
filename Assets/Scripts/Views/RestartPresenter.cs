using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RestartPresenter : MonoBehaviour
{

  public Text restartText;

  private RestartSignal _restartSignal;
  private ResetSignal _resetSignal;


  [Inject]
  public void Init(RestartSignal restartSignal, ResetSignal resetSignal)
  {
    _restartSignal = restartSignal;
    _resetSignal = resetSignal;
  }


  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  void Start()
  {
    Debug.Log("Restart Pres started");
    _restartSignal += UpdateRestartText;
    restartText = GetComponent<Text>();
  }

  public void UpdateRestartText()
  {
    restartText.text = "Press r to restart";
  }

  void Update()
  {
    if (Input.GetKey("r"))
    {
      restartText.text = "";
      _resetSignal.Fire();
    }
  }

    void OnDisable()
  {
    _restartSignal -= UpdateRestartText;
  }
}
