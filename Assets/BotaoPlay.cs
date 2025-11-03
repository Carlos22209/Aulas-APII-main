using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoPlay : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Flappy Birdo");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
