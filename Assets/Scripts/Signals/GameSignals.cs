using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

// Controller Signals
public class ChangeSceneSignal : Signal<ChangeSceneSignal, int> { }
public class AreaClickedSignal : Signal<AreaClickedSignal, string> { }
public class GameStatusChangedSignal : Signal<GameStatusChangedSignal, string, bool> { }

public class CurrentMarkChangedSignal : Signal<CurrentMarkChangedSignal, string> {}

public class RestartSignal : Signal<RestartSignal> {}
public class ResetSignal : Signal<ResetSignal> {}

// Presenter Signals
public class ShowTextSignal : Signal<ShowTextSignal, string> { }

