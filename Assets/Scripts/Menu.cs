using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [HideInInspector] [SerializeField] private GameObject _menu;
     
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            MenuOffOn();
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void MenuOffOn()
    {
        if (_menu.activeSelf)
        {
            _menu.SetActive(false);
        }
        else _menu.SetActive(true);
    }
}
