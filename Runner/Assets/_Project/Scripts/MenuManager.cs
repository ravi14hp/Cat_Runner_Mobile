using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button Button;

    void Start()
    {
        Button.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Game"));
    }
}
