using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string gameSceneID;

    public void StartGame()
    {
        LoadLevel(gameSceneID);
    }

    public void LoadLevel(string sceneID)
    {
        Debug.Log($"Loading scene: {sceneID}");
        SceneManager.LoadScene(sceneID);
    }
}
