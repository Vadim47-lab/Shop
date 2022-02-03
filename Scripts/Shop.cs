using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("Array")]
    [SerializeField] private int[] _price;
    [SerializeField] private string[] _name;
    [SerializeField] private int[] _amountToys;
    [SerializeField] private int[] _initialAmountToys;
    [SerializeField] private TMP_Text[] _toyText;
    [SerializeField] private GameObject[] _toy;

    [Header("GameObject")]
    [SerializeField] private GameObject _store;
    [SerializeField] private People _people;

    [Header("Variables")]
    [SerializeField] private TMP_Text _textCheck;
    [SerializeField] private int _startAmount;
    [SerializeField] private int _endAmount;
    [SerializeField] private int _startPrice;
    [SerializeField] private int _endPrice;
    [SerializeField] private int _zeroAmount;

    [Header("Variables Toys")]
    [SerializeField] private int _firstToy;
    [SerializeField] private int _secondToy;
    [SerializeField] private int _thirdToy;
    [SerializeField] private int _fourthToy;

    public string[] TransferName { get; private set; }
    public int[] TransferPrice { get; private set; }

    private void Start()
    {
        for (int count = 0; count < _amountToys.Length; count++)
        {
            _initialAmountToys[count] = _amountToys[count];
        }

        for (int count = 0; count < _name.Length; count++)
        {
            AddName(count);
        }

        for (int count = 0; count < _price.Length; count++)
        {
            AddPrice(count);
        }

        for (int count = 0; count < _amountToys.Length; count++)
        {
            AddAmount(count);
        }

        TransferName = _name;
        TransferPrice = _price;
    }

    private void Update()
    {
        if (_people.CloseStore == true)
        {
            _store.SetActive(false);
        }
        else
        {
            _store.SetActive(true);
        }

        for (int count = 0; count < _toyText.Length; count++)
        {
            ShowDescription(count, _toyText[count]);
        }

        for (int count = 0; count < _amountToys.Length; count++)
        {
            if (_amountToys[count] == _zeroAmount)
            {
                _toy[count].SetActive(false);
            }

            else if (_amountToys[count] != _zeroAmount)
            {
                _toy[count].SetActive(true);
            }
        }
    }

    public void GetToy(int count)
    {
        if (People.Money >= _price[count])
        {
            People.Money -= TransferPrice[count];

            _amountToys[count]--;
        }
    }

    public void BuyToy(int count)
    {
        _people.GetToy(count);
    }

    public void CreateCheck(int count)
    {
        _people.CreateCheck(count, _textCheck);
    }

    public void ReturnToy(int count)
    {
        if (People.Money < MainMenu.Result)
        {
            if (_amountToys[count] <= _initialAmountToys[count])
            {
                _amountToys[count]++;

                _people.ReturnMoney(count);
            }
        }
    }

    private void AddName(int count)
    {
        if (count == _firstToy)
        {
            _name[count] = "Плюшевый мишка";
        }

        if (count == _secondToy)
        {
            _name[count] = "Резиновый кубик";
        }

        if (count == _thirdToy)
        {
            _name[count] = "Резиновый мяч";
        }

        if (count == _fourthToy)
        {
            _name[count] = "Резиновая утка";
        }
    }

    private void AddPrice(int count)
    {
        _price[count] = Random.Range(_startPrice, _endPrice);
    }

    private void AddAmount(int count)
    {
        _amountToys[count] = Random.Range(_startAmount, _endAmount);
    }

    private void ShowDescription(int count, TMP_Text toyText)
    {
        toyText.text = "Название: " + _name[count] + ",\nколичество: " + _amountToys[count] + ",\nцена: " + _price[count] + ".";
    }
}