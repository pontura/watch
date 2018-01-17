using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour {

	public LevelCreator levelCreator;
	public Board board;
	public List<LevelData> levels;
	public int activeLevel = 0;
	public LevelData activeLevelData;
	// por si hay varios niveles que empiece siempre en el primero
	public LevelData replayLevelData;

	public void Init() {
		board.Init ();
		activeLevelData =  levels [activeLevel];
		replayLevelData = activeLevelData;
		Construct ();
	}
	public void GotoDoor(int id)
	{
		activeLevelData = activeLevelData.GetDataByID(id).link;
		print ("GOTO " + activeLevelData);
		StartPlaying ();
		Construct ();
	}
	public void Replay()
	{
		activeLevelData = replayLevelData;
		StartPlaying ();
		Construct ();
	}
	public void LoadNextLevel()
	{
		activeLevel++;
		if (activeLevel > levels.Count-1)
			activeLevel = 0;
		activeLevelData =  levels [activeLevel];
		replayLevelData = activeLevelData;
		StartPlaying ();
		Construct ();
	}
	void StartPlaying()
	{		
		levelCreator.Reset ();	
	}
	void Construct()
	{		
		board.SetWalls (activeLevelData.walls);
		foreach (SceneObject so in activeLevelData.GetComponentsInChildren<SceneObject>())
		{
			levelCreator.Add (so);		
		}				
	}
}
