using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private readonly Toy _toy;

    [Header("Array")]
    [SerializeField] private GameObject[] _toys;
    [SerializeField] private TMP_Text[] _toyText;

    [Header("GameObject")]
    [SerializeField] private GameObject _store;
    [SerializeField] private People _people;
    [SerializeField] private TMP_Text _textCheck;

    [Header("Variables")]
    [SerializeField] private int _zeroAmount;

    public string[] TransferName { get; private set; }
    public int[] TransferPrice { get; private set; }

    private void Start()
    {
        _toy.AddInfo();

        for (int count = 0; count < _toy.AmountToys.Length; count++)
        {
            _toy.AddAmount(count);
            _toy.InitialAmountToys[count] = _toy.AmountToys[count];
        }

        for (int count = 0; count < _toy.Name.Length; count++)
        {
            _toy.AddName(count);
        }

        for (int count = 0; count < _toy.Price.Length; count++)
        {
            _toy.AddPrice(count);
        }

        TransferName = _toy.Name;
        TransferPrice = _toy.Price;
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

        for (int count = 0; count < _toy.AmountToys.Length; count++)
        {
            if (_toy.AmountToys[count] == _zeroAmount)
            {
                _toys[count].SetActive(false);
            }

            else if (_toy.AmountToys[count] != _zeroAmount)
            {
                _toys[count].SetActive(true);
            }
        }
    }

    public void GetToy(int count)
    {
        if (People.Money >= _toy.Price[count])
        {
            People.Money -= TransferPrice[count];

            _toy.AmountToys[count]--;
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
            if (_toy.AmountToys[count] <= _toy.InitialAmountToys[count])
            {
                _toy.AmountToys[count]++;

                _people.ReturnMoney(count);
            }
        }
    }

    public void ShowDescription(int count, TMP_Text toyText)
    {
        toyText.text = "Название: " + _toy.Name[count] + ",\nколичество: " + _toy.AmountToys[count] + ",\nцена: " + _toy.Price[count] + ".";
    }
}

public class Toy
{
    private int _startPrice;
    private int _endPrice;
    private int _startAmount;
    private int _endAmount;

    private int _firstToy;
    private int _secondToy;
    private int _thirdToy;
    private int _fourthToy;

    public int[] Price { get; private set; }
    public string[] Name { get; private set; }
    public int[] AmountToys { get; private set; }
    public int[] InitialAmountToys { get; private set; }

    public void AddInfo()
    {
        _startAmount = 1;
        _endAmount = 4;
        _startPrice = 100;
        _endPrice = 300;

        _firstToy = 1;
        _secondToy = 2;
        _thirdToy = 3;
        _fourthToy = 4;
    }

    public void AddName(int count)
    {
        if (count == _firstToy)
        {
            Name[count] = "Плюшевый мишка";
        }

        if (count == _secondToy)
        {
            Name[count] = "Резиновый кубик";
        }

        if (count == _thirdToy)
        {
            Name[count] = "Резиновый мяч";
        }

        if (count == _fourthToy)
        {
            Name[count] = "Резиновая утка";
        }
    }

    public void AddPrice(int count)
    {
        Price[count] = Random.Range(_startPrice, _endPrice);
    }

    public void AddAmount(int count)
    {
        for (int i = 0; i < 3; i++)
        {
            InitialAmountToys[i] = 1;
        }

        AmountToys[count] = Random.Range(_startAmount, _endAmount);
    }
}