using UnityEngine;
//by furkanyldz
public class GameDirector : MonoBehaviour
{
    public PipeSpawner pipeSpawner;
    public MenuManager menuManager;
    public Bird bird;


    void Start()
    {
        menuManager.RestartGame();
        QualitySettings.vSyncCount = 0; 
        Application.targetFrameRate = 72;
    }

    public void GameOver()
    {
        menuManager.FetchRestartMenu();
        pipeSpawner.StopAllPipes();
    }

    public void RestartGame()
    {
        pipeSpawner.ClearAllPipesAndRestart();
        menuManager.RestartGame();
        bird.RestartBird();
    }

}
