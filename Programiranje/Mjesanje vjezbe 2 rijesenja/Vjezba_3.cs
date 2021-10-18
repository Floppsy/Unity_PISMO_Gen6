using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vjezba_3 : MonoBehaviour
{
    //Imaš javnu vrijednost „pokrajine“ i svaka ti daje 1 coin po sekundi. Na tipku D 
    //oduzmi 50% svojih pokrajina, a na tipku A dodaj random između 1 i 5 pokrajina.
    //Neka se broj novcica ispisuje na UI, te također broj pokrajina.

    public int pokrajine;//varijabla pokrajine
    int coin = 1;//varijabla vrijednosti coina koja je 1
    public Text coinText;//text koji pokazuje za količinu coina
    public Text pokrajineText;//text koji pokazuje količinu pokrajini

    private void Start()//metoda start
    {
        StartCoroutine("Coins", 1f);//pozivanje coroutine Coins
    }

    IEnumerator Coins()//coroutine Coins
    {
        pokrajine += coin;//broj pokrajini i za svaku pokrajinu dobijemo 1 coin
        yield return new WaitForSeconds(1);//vremenski period koji definira svako koliko će se izvoditi coroutine
        coinText.text = coin.ToString();//ispisivanje u ui broj coina
        pokrajineText.text = pokrajine.ToString();//ispisivanje u ui broj pokrajini
    }

    private void Update()//metoda update
    {
        if (Input.GetKey(KeyCode.D))//input za tipku D
        {
            pokrajine /= 2;//gubljenje 50% pokrajini
            coinText.text = coin.ToString();//ispisivanje u ui broj coina
            pokrajineText.text = pokrajine.ToString();//ispisivanje u ui broj pokrajini
        }
        if (Input.GetKey(KeyCode.A))//input za tipku A
        {
            pokrajine += Random.Range(1, 6);//dodavanje random broj pokrajini između 1 i 6, 6 je exclusive
            coinText.text = coin.ToString();//ispisivanje broja coina na ui
            pokrajineText.text = pokrajine.ToString();//ispisivanje broja pokrajini na ui
        }    
    }
}
