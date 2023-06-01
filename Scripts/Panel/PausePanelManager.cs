using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanelManager : MonoBehaviour
{
    //ボタン
    [SerializeField] private Button restartButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button giveupButton;
    [SerializeField] private Button settingButton;
    //ボタンの親オブジェクト
    [SerializeField] private GameObject parentButton;

    private PlayerController playerController;
    [SerializeField] private GameObject player;
    //遷移先
    [SerializeField] private GameObject playingPanel;
    [SerializeField] private GameObject gameOverPanle;

    private void OnEnable()
    {
        playerController = player.GetComponent<PlayerController>();
        Time.timeScale = 0;//時間を止める
        parentButton.SetActive(true);
        restartButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;//時間を止める
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        continueButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;//ゲーム再開
            playingPanel.SetActive(true);
            gameOverPanle.SetActive(false);
            this.gameObject.SetActive(false);
        });

        giveupButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;//ゲーム再開
            playerController.Death();
            playingPanel.SetActive(true);
            this.gameObject.SetActive(false);
        });

        settingButton.onClick.AddListener(() =>
        {
            
        });
    }
}
