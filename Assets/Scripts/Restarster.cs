using UnityEngine;
using UnityEngine.SceneManagement;


public class Restarter : MonoBehaviour
{
    public void ChangeScene()
    {
    SceneManager.LoadScene("Main");
    }
}
