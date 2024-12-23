using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Fuel")]
    [SerializeField] private Image img_fuel;
    [SerializeField] private Gradient gradient_fuel; 
    [SerializeField] private float maxFuel = 15f;
    public float curFuel = 0f;

    [Header("Restart Btn")]
    [SerializeField] private Button btn_restart;

    [Header("InGame")]
    [SerializeField] private TextMeshProUGUI text_distance;
    public float distance;

    public void Start()
    {
        Instance = this;
        btn_restart.gameObject.SetActive(false);

        curFuel = maxFuel;
    }

    private void Update()
    {
        img_fuel.fillAmount = curFuel / maxFuel;
        img_fuel.color = gradient_fuel.Evaluate(img_fuel.fillAmount); // 수치를 색깔로 표현

        text_distance.text = $"Distance : {distance.ToString("F0")}";  // no decimal show up

        if (curFuel <= 0f)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        btn_restart.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnBtnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
