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
        for (int count = 0; count < _toy._amountToys.Length; count++)
        {
            _toy._initialAmountToys[count] = _toy._amountToys[count];
        }

        TransferName = _toy._name;
        TransferPrice = _toy._price;
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

         for (int count = 0; count < _toy._amountToys.Length; count++)
         {
             if (_toy._amountToys[count] == _zeroAmount)
             {
                 _toys[count].SetActive(false);
             }

             else if (_toy._amountToys[count] != _zeroAmount)
             {
                 _toys[count].SetActive(true);
             }
         }
    }

    public void GetToy(int count)
    {
        if (People.Money >= _toy._price[count])
        {
            People.Money -= TransferPrice[count];

            _toy._amountToys[count]--;
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
            if (_toy._amountToys[count] <= _toy._initialAmountToys[count])
            {
                _toy._amountToys[count]++;

                _people.ReturnMoney(count);
            }
        }
    }

    public void ShowDescription(int count, TMP_Text toyText)
    {
        toyText.text = "Название: " + _toy._name[count] + ",\nколичество: " + _toy._amountToys[count] + ",\nцена: " + _toy._price[count] + ".";
    }
}