using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{

  public override void InstallBindings()
  {
    PresenterSignals();
    ControllerSignals();
    Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
    Container.Bind<IGameManager>().To<GameManager>().AsSingle();
  }

  private void PresenterSignals()
  {
    Container.DeclareSignal<ShowTextSignal>();
  }

  private void ControllerSignals()
  {
    Container.DeclareSignal<ChangeSceneSignal>();
    Container.DeclareSignal<GameStatusChangedSignal>();
    Container.DeclareSignal<AreaClickedSignal>();
    Container.DeclareSignal<CurrentMarkChangedSignal>();
  }
}
