using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _returnMenuButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _menu;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _returnMenuButton.onClick.AddListener(OnReturnMenuButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        _returnMenuButton.onClick.RemoveListener(OnReturnMenuButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _menu.SetActive(true);
        }
    }

    private void OnContinueButtonClick()
    {
        _menu.SetActive(false);
    }

    private void OnReturnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}