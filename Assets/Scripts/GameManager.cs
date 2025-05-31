using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton para que se pueda acceder fácilmente desde otros scripts
    public GameObject startPanel; // Referencia al panel de inicio
    public GameObject gameOverPanel; // Referencia al panel de fin de partida
    private bool gameStarted = false; // Para saber si el juego ya ha comenzado

    private void Awake()
    {
        if (Instance == null) Instance = this; // Se asegura que haya solo un GameManager
    }

    private void Start()
    {
        Time.timeScale = 0f; // Pausa el juego al iniciar
        startPanel.SetActive(true); // Muestra el panel de inicio
        gameOverPanel.SetActive(false); // Oculta el panel de Game Over
    }

    public void StartGame()
    {
        Time.timeScale = 1f; // Reanuda el juego
        gameStarted = true;
        startPanel.SetActive(false); // Oculta el panel de inicio
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Pausa el juego
        gameOverPanel.SetActive(true); // Muestra el panel de Game Over
    }

    public void RestartGame()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

