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

    [Header("ReturnButton")]
    [SerializeField] private Button _returnBearButton;
    [SerializeField] private Button _returnCubeButton;
    [SerializeField] private Button _returnBallButton;
    [SerializeField] private Button _returnDuckButton;

    [Header("GameObject")]
    [SerializeField] private Shop _shop;

    private int _count;

    private void OnEnable()
    {
        _bearButton.onClick.AddListener(OnBuyBearButtonClick);
        _cubeButton.onClick.AddListener(OnBuyCubeButtonClick);
        _ballButton.onClick.AddListener(OnBuyBallButtonClick);
        _duckButton.onClick.AddListener(OnBuyDuckButtonClick);

        _payButton.onClick.AddListener(OnPayButtonClick);

        _returnBearButton.onClick.AddListener(OnReturnBearButtonClick);
        _returnCubeButton.onClick.AddListener(OnReturnCubeButtonClick);
        _returnBallButton.onClick.AddListener(OnReturnBallButtonClick);
        _returnDuckButton.onClick.AddListener(OnReturnDuckButtonClick);
    }

    private void OnDisable()
    {
        _bearButton.onClick.RemoveListener(OnBuyBearButtonClick);
        _cubeButton.onClick.RemoveListener(OnBuyCubeButtonClick);
        _ballButton.onClick.RemoveListener(OnBuyBallButtonClick);
        _duckButton.onClick.RemoveListener(OnBuyDuckButtonClick);

        _payButton.onClick.RemoveListener(OnPayButtonClick);

        _returnBearButton.onClick.RemoveListener(OnReturnBearButtonClick);
        _returnCubeButton.onClick.RemoveListener(OnReturnCubeButtonClick);
        _returnBallButton.onClick.RemoveListener(OnReturnBallButtonClick);
        _returnDuckButton.onClick.RemoveListener(OnReturnDuckButtonClick);
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

    private void OnBuyBearButtonClick()
    {
        EventButtonPress();

        Count0();

        _shop.BuyToy(_count);
    }

    private void OnBuyCubeButtonClick()
    {
        EventButtonPress();

        Count1();

        _shop.BuyToy(_count);
    }

    private void OnBuyBallButtonClick()
    {
        EventButtonPress();

        Count2();

        _shop.BuyToy(_count);
    }

    private void OnBuyDuckButtonClick()
    {
        EventButtonPress();

        Count3();

        _shop.BuyToy(_count);
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

    private void OnPayButtonClick()
    {
        EventButtonPress();

        _shop.BuyToy(_count);
    }

    private void EventButtonPress()
    {
        _buttonPress?.Invoke();
    }
}