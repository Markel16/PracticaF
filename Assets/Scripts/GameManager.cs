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

    // Este m�todo puede usarse si en alg�n momento necesitas forzar el inicio
    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    // Se llama cuando el jugador colisiona
    public void GameOver()
    {
        // Reinicia autom�ticamente la escena actual al morir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // M�todo adicional si quieres reiniciar manualmente desde otro script
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
