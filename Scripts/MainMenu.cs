using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _applyChangesButton;
    [SerializeField] private TMP_InputField _inputMoney;
    [SerializeField] private TMP_Text _textMoney;

    public static int Result { get; private set; }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _applyChangesButton.onClick.AddListener(OnApplyChangesButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _applyChangesButton.onClick.RemoveListener(OnApplyChangesButtonClick);
    }

    private void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnApplyChangesButtonClick()
    {
        if (_inputMoney.text == "")
        {
            _textMoney.text = "Ошибка!";
        }
        else
        {
            Result = Convert.ToInt32(_inputMoney.text);
            People.Money = Result;

            _textMoney.text = "Деньги = " + _inputMoney.text;
        }
    }
}