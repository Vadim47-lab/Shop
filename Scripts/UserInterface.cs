using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private UnityEvent _buttonPress;

    [Header("Button")]
    [SerializeField] private Button _bearButton;
    [SerializeField] private Button _cubeButton;
    [SerializeField] private Button _ballButton;
    [SerializeField] private Button _duckButton;

    [SerializeField] private Button _payButton;
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;
    [SerializeField] private Button _continueButton;


    [Header("ReturnButton")]
    [SerializeField] private Button _returnBearButton;
    [SerializeField] private Button _returnCubeButton;
    [SerializeField] private Button _returnBallButton;
    [SerializeField] private Button _returnDuckButton;

    [Header("GameObject")]
    [SerializeField] private Shop _shop;
    [SerializeField] private GameObject _purchase;
    [SerializeField] private GameObject _check;

    private int _count;
    public int[] _toys;

    private void OnEnable()
    {
        _bearButton.onClick.AddListener(OnGetBearButtonClick);
        _cubeButton.onClick.AddListener(OnGetCubeButtonClick);
        _ballButton.onClick.AddListener(OnGetBallButtonClick);
        _duckButton.onClick.AddListener(OnGetDuckButtonClick);

        _returnBearButton.onClick.AddListener(OnReturnBearButtonClick);
        _returnCubeButton.onClick.AddListener(OnReturnCubeButtonClick);
        _returnBallButton.onClick.AddListener(OnReturnBallButtonClick);
        _returnDuckButton.onClick.AddListener(OnReturnDuckButtonClick);

        _payButton.onClick.AddListener(OnPayButtonClick);
        _yesButton.onClick.AddListener(OnYesButtonClick);
        _noButton.onClick.AddListener(OnNoButtonClick);
        _continueButton.onClick.AddListener(OnContinueButtonClick);
    }

    private void OnDisable()
    {
        _bearButton.onClick.RemoveListener(OnGetBearButtonClick);
        _cubeButton.onClick.RemoveListener(OnGetCubeButtonClick);
        _ballButton.onClick.RemoveListener(OnGetBallButtonClick);
        _duckButton.onClick.RemoveListener(OnGetDuckButtonClick);

        _returnBearButton.onClick.RemoveListener(OnReturnBearButtonClick);
        _returnCubeButton.onClick.RemoveListener(OnReturnCubeButtonClick);
        _returnBallButton.onClick.RemoveListener(OnReturnBallButtonClick);
        _returnDuckButton.onClick.RemoveListener(OnReturnDuckButtonClick);

        _payButton.onClick.RemoveListener(OnPayButtonClick);
        _yesButton.onClick.RemoveListener(OnYesButtonClick);
        _noButton.onClick.RemoveListener(OnNoButtonClick);
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
    }

    private void Count0()
    {
        _count = 0;
    }

    private void Count1()
    {
        _count = 1;
    }

    private void Count2()
    {
        _count = 2;
    }

    private void Count3()
    {
        _count = 3;
    }

    private void OnGetBearButtonClick()
    {
        EventButtonPress();

        Count0();

        _toys[0]++;

        _shop.GetToy(_count);
    }

    private void OnGetCubeButtonClick()
    {
        EventButtonPress();

        Count1();

        _toys[1]++;

        _shop.GetToy(_count);
    }

    private void OnGetBallButtonClick()
    {
        EventButtonPress();

        Count2();

        _toys[2]++;

        _shop.GetToy(_count);
    }

    private void OnGetDuckButtonClick()
    {
        EventButtonPress();

        Count3();

        _toys[3]++;

        _shop.GetToy(_count);
    }

    private void OnPayButtonClick()
    {
        EventButtonPress();

        _purchase.SetActive(true);
    }

    private void OnReturnBearButtonClick()
    {
        EventButtonPress();

        Count0();

        _shop.ReturnToy(_count);
    }

    private void OnReturnCubeButtonClick()
    {
        EventButtonPress();

        Count1();

        _shop.ReturnToy(_count);
    }

    private void OnReturnBallButtonClick()
    {
        EventButtonPress();

        Count2();

        _shop.ReturnToy(_count);
    }

    private void OnReturnDuckButtonClick()
    {
        EventButtonPress();

        Count3();

        _shop.ReturnToy(_count);
    }

    private void OnYesButtonClick()
    {
        EventButtonPress();

        for (int i = 0; i < _toys.Length; i++)
        {
            _shop.BuyToy(i);
        }

        for (int i = 0; i < _toys.Length; i++)
        {
            _shop.CreateCheck(i);
        }

        for (int i = 0; i < _toys.Length; i++)
        {
            _toys[i] = 0;
        }

        _check.SetActive(true);
    }

    private void OnNoButtonClick()
    {
        EventButtonPress();

        _purchase.SetActive(false);
    }

    private void OnContinueButtonClick()
    {
        _check.SetActive(false);
        _purchase.SetActive(false);
    }

    private void EventButtonPress()
    {
        _buttonPress?.Invoke();
    }
}