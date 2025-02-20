using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GmaeManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;

    int enemiesLeft = 0;

    const String ENEMIES_LEFT_STRING = "Enemies Left : ";
    public void AdjustEnemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();

        if (enemiesLeft <= 0)
        {
            
            youWinText.SetActive(true);
        } 
    }
    public void RestartLevelButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton()
    {
        Debug.LogWarning("유니티 에디션에서는 상요 안됨!");
        Application.Quit();
    }
}
