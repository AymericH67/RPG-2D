using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ItemId
{
    Money = 0,
}

[System.Serializable]
public class Item
{
    [SerializeField]private string name;
    public ItemId id;

    public int number = 0;
}

public class CharactersInfoes : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyTxt;


    private static  Item[] inventory;

    public int maxHealth = 3;
    public int health = 3;

    [SerializeField]
    private Transform heartPrefab;
    [SerializeField]
    private Transform heartParent;
    private List<GameObject> hearthObj = new List<GameObject> ();

    private GameManager manager;


    private void Start()
    {
        manager = GetComponent<GameManager>();

        inventory = new Item[1];
        inventory[0] = new Item();

        TakeDamage(0);
    }

    private void Update()
    {
        moneyTxt.text = " : " + inventory[((int)ItemId.Money)].number;
        print("health" + health);
    }

    private void InitHealth()
    {
        health = maxHealth;

        for (int i = 0; i < maxHealth; i++)
        {
            Transform curHeart = Instantiate(heartPrefab);
            curHeart.SetParent(heartParent);
            hearthObj.Add(curHeart.gameObject);
        }
    }

    private void TakeDamage(int _damage)
    {
        health -= _damage;

        /// reafficher les degat
        for(int i = 0; i < maxHealth; i++)
        {
            bool _state = i > health ? true : false;

            hearthObj[i].SetActive(_state);
        }
    }

    public static void AddItem(ItemId _id, int _number)
    {
        inventory[((int)_id)].number += _number;
    }
}


