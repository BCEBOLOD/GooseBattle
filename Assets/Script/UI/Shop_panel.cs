using UnityEngine.UI;
using UnityEngine;

public class Shop_panel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Collider2D _coll2d;
    [Space]
    [SerializeField] private int _price;
    [SerializeField] private PlayerContoll _player;

    [SerializeField] private Button _buy;
    [SerializeField] private Text _textBuy;

    private void Start()
    {
        _coll2d = GetComponent<Collider2D>();
        UpdatePrice();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerContoll playerContoll))
        {
            _panel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerContoll playerContoll))
        {
            _panel.SetActive(false);
        }
    }

    public void OnBuy()
    {
        if(_player.Coin >= _price)
        {
            _player.ChangedAll(3,3,_price);            
            _price += 1;            
            UpdatePrice();
        }
    }

    private void UpdatePrice()
    {
        _textBuy.text = "Price =" + _price.ToString();
    }

}
