using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton para acceso global

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f; // Asegura que el juego comience en marcha
    }

    // Este método puede usarse si en algún momento necesitas forzar el inicio
    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    // Se llama cuando el jugador colisiona
    public void GameOver()
    {
        // Reinicia automáticamente la escena actual al morir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Método adicional si quieres reiniciar manualmente desde otro script
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
