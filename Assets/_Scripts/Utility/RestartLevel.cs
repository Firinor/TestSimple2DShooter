using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartLevel : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Restart);
    }
    public void Restart()
    {
        Bootstrap.Restart();
        SceneManager.LoadScene(0);
    }
}
