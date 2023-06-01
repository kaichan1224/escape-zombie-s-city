using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateManager : MonoBehaviour
{
    [SerializeField] GameObject playingScene;
    [SerializeField] GameObject gameOverScene;
    [SerializeField] GameObject pauseScene;
    [SerializeField] PlayerController playerController;

    private void Start()
    {
        pauseScene.SetActive(true);
    }

    private void Update()
    {
        
    }
}
