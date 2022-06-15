using UnityEngine;
using TMPro;

public class People : MonoBehaviour
{
    [Header("Array")]
    [SerializeField] private TMP_Text[] _toyText;
    [SerializeField] private int[] _amount;
    [SerializeField] private GameObject[] _toys;

    [Header("Variables")]
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private GameObject _backpack;
    [SerializeField] private Shop _shop;
    [SerializeField] private Toy _toy;
    [SerializeField] private UserInterface _userInterface;
    [SerializeField] private int _zeroAmount;

    public static int Money { get; set; }
    public bool CloseStore { get; private set; }

    private void Start()
    {
        CloseStore = false;

        for (int count = 0; count < _amount.Length; count++)
        {
            _toys[count].SetActive(false);
        }
    }

    private void Update()
    {
        _moneyText.text = "Деньги = " + Money;

        if (Input.GetKey(KeyCode.Q))
        {
            CloseStore = true;
            _backpack.SetActive(true);

            for (int count = 0; count < _toyText.Length; count++)
            {
                if (_amount[count] != _zeroAmount) 
                {
                    _toys[count].SetActive(true);
                    ShowDescription(count, _toyText[count]);
                }

                else
                {
                    _toys[count].SetActive(false);
                }
            }
        }
        else if (Input.GetKey(KeyCode.E))
        {
            CloseStore = false;
            _backpack.SetActive(false);
        }
    }

    public void GetToy(int count)
    {
        _amount[count] += _userInterface.Toys[count];
    }

    public void ReturnMoney(int count)
    {
        Money += _toy.TransferPrice;

        _amount[count]--;
    }

    public void CreateCheck(int count, TMP_Text textCheck)
    {
        textCheck.text = "Название: " + _toy.TransferName + ",\nколичество: " + _amount[count] + ",\nцена: " + _toy.TransferPrice + ".";
    }

    private void ShowDescription(int count, TMP_Text toyText)
    {
        toyText.text = "Название: " + _toy.TransferName + ",\nколичество: " + _amount[count] + "\nЦена: " + _toy.TransferPrice + ".";
    }
}