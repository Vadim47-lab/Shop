using UnityEngine;

public class Toy : MonoBehaviour
{
    private int _price;
    private string _name;
    private int _amountToys;

    public string TransferName { get; private set; }
    public int TransferPrice { get; private set; }
    public int TransferAmountToys { get; set; }

    private void Start()
    {
        TransferName = _name;
        TransferPrice = _price;
        TransferAmountToys = _amountToys;
    }

    private void Update()
    {
        _name = TransferName;
        _price = TransferPrice;
        _amountToys = TransferAmountToys;
    }

    public Toy(int price, string name, int amountToys)
    {
        _price = price;
        _name = name;
        _amountToys = amountToys;
    }
}