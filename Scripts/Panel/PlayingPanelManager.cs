using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingPanelManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    private void OnEnable()
    {
        pauseButton.onClick.AddListener(() =>
        {
            pausePanel.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }

    private void Update()
    {
        if (player.isDead)
        {
            gameOverPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
