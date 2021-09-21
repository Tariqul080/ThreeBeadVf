using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenManejer : MonoBehaviour
{
   public void playGame()
   {
        SceneManager.LoadScene("MainGame");
   }
    public void QuirGame()
    {
        Application.Quit();
    }
}
