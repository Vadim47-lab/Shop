using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    private readonly Toy _toy;
    private Toy[] _toys = { new Toy(100, "Плюшевый Мишка", 3), new Toy(200, "Куб", 2), new Toy(150, "Мяч", 1), new Toy(300, "Утка", 4) };

    [Header("Array")]
    [SerializeField] private GameObject[] _toysGameObject;
    [SerializeField] private TMP_Text[] _toyText;

    [Header("GameObject")]
    [SerializeField] private GameObject _store;
    [SerializeField] private People _people;
    [SerializeField] private TMP_Text _textCheck;

    [Header("Variables")]
    [SerializeField] private int _zeroAmount;
    [SerializeField] private int _initialAmountToys;

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
            ShowDescription(_toyText[count]);
        }

         for (int count = 0; count < _toys.Length; count++)
         {
             if (_toy.TransferAmountToys == _zeroAmount)
             {
                _toysGameObject[count].SetActive(false);
             }

             else if (_toy.TransferAmountToys != _zeroAmount)
             {
                _toysGameObject[count].SetActive(true);
             }
         }
    }

    public void GetToy(int count)
    {
        if (People.Money >= _toy.TransferPrice)
        {
            People.Money -= _toy.TransferPrice;

            _toy.TransferAmountToys--;
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
            if (_toy.TransferAmountToys <= _initialAmountToys)
            {
                _toy.TransferAmountToys++;

                _people.ReturnMoney(count);
            }
        }
    }

    public void ShowDescription(TMP_Text toyText)
    {
        toyText.text = "Название: " + _toy.TransferName + ",\nколичество: " + _toy.TransferAmountToys + ",\nцена: " + _toy.TransferPrice + ".";
    }
}