using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UiShop : MonoBehaviour
{
    public GameObject firstItemInShop;
    public GameObject handGun;
    public GameObject handGunSecond;
    public int firstItemInShopPrice = 15;
    private collectMeat meatCollector; // Reference to the collectMeat script

    public GameObject closeButton;




    private void Start()
    {
        meatCollector = FindObjectOfType<collectMeat>(); // Find the collectMeat script in the scene


        if (meatCollector != null)
        {
            Button button1 = firstItemInShop.GetComponent<Button>();

            if (button1 != null)
            {
                button1.onClick.AddListener(OnFirstItemClicked);
            }
        }
        else
        {
            Debug.LogError("collectMeat script not found in the scene.");
        }

        Button button2 = closeButton.GetComponent<Button>();
        if (button2 != null)
        {
            button2.onClick.AddListener(OnloseButtonClicked);
        }

    }

    private void Update()
    {
        // You can add any update logic here if needed.
    }

    private void OnFirstItemClicked()
    {
        Debug.Log("First item in shop is pressed!");
        int currentMeatCollected = collectMeat.numberOfMeatCollected;
        Debug.Log("First item in shop is pressed! Current meat collected: " + currentMeatCollected);

        if(currentMeatCollected>= firstItemInShopPrice)
        {
            handGun.SetActive(false);
            handGunSecond.SetActive(true);
            collectMeat.ChangeAmount(currentMeatCollected - firstItemInShopPrice);
        }






    }

    private void OnloseButtonClicked()
    {
        gameObject.SetActive(false);
    }

    private void OnThirdItemClicked()
    {
        Debug.Log("Third item in shop is pressed!");
    }

    private void OnFourthItemClicked()
    {
        Debug.Log("Fourth item in shop is pressed!");
    }



}
