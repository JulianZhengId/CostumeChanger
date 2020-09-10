using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject UndestroyedPlayer;
    public static GameController GC;
    public GameObject photonPlayer;
    public GameObject playerSet;

    public void OnClickLoadSene()
    {
        SceneManager.LoadScene(1);
    }

    private void Awake()
    {
        Debug.Log("Awake");
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(UndestroyedPlayer);
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1)
        {
            playerSet = Instantiate(photonPlayer, new Vector3(0, 0, 0), Quaternion.identity);
            UndestroyedPlayer.transform.parent = playerSet.transform;
            
        }
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    // called third
    void Start()
    {
        Debug.Log("Start");
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public GameObject GetPlayerSet()
    {
        return playerSet;
    }
}
