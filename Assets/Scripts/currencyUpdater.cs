using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currencyUpdater : MonoBehaviour
{
    public Text currencyText;
    // Start is called before the first frame update
    void Start()
    {
        currencyText.text = CurrencyManager.Instance.currencyPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = CurrencyManager.Instance.currencyPoints.ToString();
    }
}
