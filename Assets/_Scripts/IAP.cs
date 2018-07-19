using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAP : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;
    public static string btc50 = "";
    public static string btc300 = "";
    public static string btc5000 = "";

    void Start()
    {
        if (m_StoreController == null)
        {
            InitializePurchasing();
        }
    }
    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(btc50, ProductType.Consumable);
        UnityPurchasing.Initialize(this, builder);

        var builder2 = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder2.AddProduct(btc300, ProductType.Consumable);
        UnityPurchasing.Initialize(this, builder2);

        var builder3 = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder3.AddProduct(btc5000, ProductType.Consumable);
        UnityPurchasing.Initialize(this, builder3);
    }
    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }
    public void BuyBTC_50()
    {
        //if (Application.internetReachability != NetworkReachability.NotReachable)
        //{
            BuyProductID(btc50);
        //}
    }

    public void BuyBTC_300()
    {
        //if (Application.internetReachability != NetworkReachability.NotReachable)
        //{
            BuyProductID(btc300);
        //}
    }

    public void BuyBTC_5000()
    {
        //if (Application.internetReachability != NetworkReachability.NotReachable)
        //{
            BuyProductID(btc5000);
        //}
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("Loi: khong co san phan hoac san pham khong ton tai tren store");
            }
        }
        else
        {
            Debug.Log("Loi: chua khoi tao Unity Purchasing day du");
        }
    }
    // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
    // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
    public void RestorePurchases()
    {
        Debug.Log("restore purchase");
        // If Purchasing has not yet been set up ...
        if (!IsInitialized())
        {
            // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("RestorePurchases started ...");

            // Fetch the Apple store-specific subsystem.
            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
            // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
            apple.RestoreTransactions((result) =>
            {
                // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                // no purchases are available to be restored.
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
                if (result)
                {

                }
                else
                {

                }

            });
        }
        // Otherwise ...
        else
        {
            // We are not running on an Apple device. No work is necessary to restore purchases.
            Debug.Log("RestorePurchases isn't supported on this platform.");
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, btc50, StringComparison.Ordinal))
        {
            Debug.Log("MuaThanhCong");
            //XU LY SU KIEN SAU KHI MUA THANH CONG O DAY
            GameManager.Instance.main.dollars += 50;
        }
        else if(String.Equals(args.purchasedProduct.definition.id, btc300, StringComparison.Ordinal))
        {
            GameManager.Instance.main.dollars += 300;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, btc5000, StringComparison.Ordinal))
        {
            GameManager.Instance.main.dollars += 5000;
        }
        else
        {
            Debug.Log("ProcessPurchase: FAIL");
        }
        return PurchaseProcessingResult.Complete;
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason
    )
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
