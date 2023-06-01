using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float limitTimeMinutes = 300f;//設定する時間
    [SerializeField] private float currentTime;//現在の残り時間
    [SerializeField] private TMP_Text currentTimeText;
    [SerializeField] private GameObject gameClearPanel;
    [SerializeField] private GameObject player;
    private PlayerController playerController;

    public bool IsActive = false;//制限時間タイマーがアクティブ状態かどうかを判定する

    private void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void Start()
    {
        OnStart();
        Debug.Log("GameTimer");
    }

    private void Update()
    {
        if (IsActive && !playerController.isDead)
        {
            string minutes = ((int)currentTime / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");
            currentTimeText.text = minutes + ":" + seconds;
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                OnStop();
                gameClearPanel.SetActive(true);
            }   
        }
    }

    public void OnStart()
    {
        currentTime = limitTimeMinutes;
        string minutes = ((int)currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");
        currentTimeText.text = minutes + ":" + seconds;
        IsActive = true;
    }
    public void OnStop()
    {
        IsActive = false;
    }
    public void OnReset()
    {
        currentTime = limitTimeMinutes;
        string minutes = ((int)currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");
        currentTimeText.text = minutes + ":" + seconds;
        OnStop();
    }
}