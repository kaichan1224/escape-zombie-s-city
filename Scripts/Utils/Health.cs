using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour,ITakeDamage
{
    [SerializeField]
    public int currentHealth;
    public int firstHealth;
    public Slider hpSlider;
    private Transform sliderTarget;
    public bool isPlayer;//バーが向く方向を判定するためのフラグ
    public UnityEvent OnDeath, OnHit;
    private bool isDead = false;
    private void Start()
    {
        sliderTarget = Camera.main.gameObject.transform;
    }

    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                if (hpSlider != null)
                {
                    hpSlider.value = (float)currentHealth / (float)firstHealth;//スライダは0〜1.0で表現するため最大HPで割って少数点数字に変換
                    hpSlider.gameObject.SetActive(false);
                }
                isDead = true;
                OnDeath?.Invoke();
            }
            else
            {
                if (hpSlider != null)
                    hpSlider.value = (float)currentHealth / (float)firstHealth;//スライダは0〜1.0で表現するため最大HPで割って少数点数字に変換
            }
        }     
    }

    private void Update()
    {
        //スライダーバーがずっと正面を向くようにする
        if(!isPlayer && hpSlider != null)
            hpSlider.transform.LookAt(sliderTarget);
    }

    public void InitializeHealth(int startingHealth)
    {
        if (startingHealth < 0)
            startingHealth = 0;
        currentHealth = startingHealth;
        firstHealth = currentHealth;
        if (hpSlider != null)
            hpSlider.value = (float)currentHealth;//HPバーの最初の値（最大HP）を設定
    }
}
