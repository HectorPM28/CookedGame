using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class HudController: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyCountrText;

    private int _currentCoins = 0;

    private void Start()
    {
        UpdateCoinText();
    }
    public void GrabCoin()
    {
        _currentCoins++;
        UpdateCoinText();
    }
    private void UpdateCoinText()
    {
        _moneyCountrText.text = _currentCoins + "x";
    }

}
