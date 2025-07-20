using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipes;
    public int pipeDistanceX;
    public int pipeSpawnPointX; //11den baþlatýyor buna bak
    private GameObject currentPipe;
    private bool isPaused;
    private bool isStarted;

    void Start()
    {
        pipeDistanceX = 9;
        pipeSpawnPointX = 16;
        isPaused = false;
        isStarted = false;
    }

    void Update()
    {
        if (!isPaused && (!isStarted && (Input.GetKeyDown(KeyCode.Mouse0))))
        {
            isStarted = true; 
            SpawnPipe();
        }
        if(isStarted && (pipeSpawnPointX - currentPipe.transform.position.x >= pipeDistanceX))
        {
           SpawnPipe();
        }
    }

    public void SpawnPipe()
    {
        float randomPositionY = Random.Range(-3.25f,3.25f); 
        var pos = new Vector2(pipeSpawnPointX, randomPositionY);
        currentPipe =  Instantiate(pipes, pos, Quaternion.identity);
    }

    public void StopAllPipes()
    {
        isStarted = false;
        isPaused = true;
        var allPipesInScene = FindObjectsByType<Pipes>(FindObjectsSortMode.None);

        foreach(var pipe in allPipesInScene)
            pipe.Stop();

    }

    public void ClearAllPipesAndRestart()
    {
        isPaused = false;
        var allPipesInScene = FindObjectsByType<Pipes>(FindObjectsSortMode.None);

        foreach (var pipe in allPipesInScene)
            Destroy(pipe.gameObject);

        //SpawnPipe(); //bu olmayýnca null exception veriyormuþ
    }
}
