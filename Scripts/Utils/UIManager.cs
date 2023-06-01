using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private PlayerController playerController;
    private bool isDead;
    public Button resetButton;
    public Button titleButton;
    public GameObject gameOverPanel;
    private bool isActivate = false;
    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerController.isDead && !isActivate)
        {
            gameOverPanel.SetActive(true);
            resetButton.onClick.AddListener(Reset);
            titleButton.onClick.AddListener(Title);
            isActivate = true;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverPanel.SetActive(false);
    }

    private void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
