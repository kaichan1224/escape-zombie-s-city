using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClearPanelManager : MonoBehaviour
{
    //ボタン
    [SerializeField] private Button quitButton;

    private void OnEnable()
    {
        Time.timeScale = 0;//時間を止める
        quitButton.onClick.AddListener(()=>
        {
            Time.timeScale = 1;//時間を止める
            SceneManager.LoadScene("TitleScene");
        });
    }
}
