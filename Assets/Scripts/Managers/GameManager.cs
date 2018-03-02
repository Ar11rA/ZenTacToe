using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : IGameManager
{

  public string gameStatus { get; set; }

  public string currentMark = GameConstants.DEFAULT_MARK;

  private int counter = 0;

  private List<List<string>> winningPositions;

  private Dictionary<string, List<string>> positions;

  private bool isGameOver = false;

  public GameManager()
  {
    positions = new Dictionary<string, List<string>>();
    winningPositions = new List<List<string>>();
    winningPositions.Add(new List<string> { "11", "22", "33" });
    winningPositions.Add(new List<string> { "11", "12", "13" });
    winningPositions.Add(new List<string> { "11", "21", "31" });
    winningPositions.Add(new List<string> { "13", "22", "31" });
    winningPositions.Add(new List<string> { "12", "22", "32" });
    winningPositions.Add(new List<string> { "13", "23", "33" });
    winningPositions.Add(new List<string> { "21", "22", "23" });
    winningPositions.Add(new List<string> { "31", "32", "33" });
  }

  public string GetCurrentMark()
  {
    return currentMark;
  }

  public string GetGameStatus()
  {
    return gameStatus;
  }

  public bool GetIsGameOver()
  {
    return isGameOver;
  }

  public void Reset() {
		isGameOver = false;
		gameStatus = "";
		counter = 0;
		currentMark = GameConstants.DEFAULT_MARK;
		positions.Clear ();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
  
  public void OnAreaClicked(string clickedIndex)
  {
    gameStatus = "Area clicked " + clickedIndex;
    if (!positions.ContainsKey(currentMark))
    {
      List<string> clickedIndices = new List<string>();
      clickedIndices.Add(clickedIndex);
      positions[currentMark] = clickedIndices;
    }
    else
    {
      positions[currentMark].Add(clickedIndex);
    }
    counter++;
    if (counter >= 5)
    {
      isGameOver = CheckGameStatus();
    }
	if (isGameOver)
    {
      gameStatus = "Player " + currentMark + " Won";
      return;
    }
	if (counter == 9 && !isGameOver) {
		isGameOver = true;
		gameStatus = "Game ends in a draw";
		return;
	}
    currentMark = (currentMark == "x") ? "o" : "x";
  }

  private bool CheckGameStatus()
  {
    List<string> currentMarkPositions = positions[currentMark];
    bool isWinning = false;
    for (int i = 0; i < winningPositions.Count; i++)
    {
      List<string> winningPosition = winningPositions[i];
      isWinning = !winningPosition.Except(currentMarkPositions).Any();
      if (isWinning)
      {
        return isWinning;
      }
    }
    return isWinning;
  }

  public void OnSceneChange(int sceneId)
  {
    Debug.Log("Scene Change triggered");
    SceneManager.LoadScene(sceneId);
  }
}
