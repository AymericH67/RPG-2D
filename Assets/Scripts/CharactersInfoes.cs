using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharactersInfoes : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyTxt;
    
    public int moneyCount = 0;
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

        InitHealth();

        TakeDamage(2);
    }

    private void Update()
    {
        moneyTxt.text = " : " + moneyCount;
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
            if (i > health)
            {
                hearthObj[i].SetActive(true);
            }
            else
            {
                hearthObj[i].SetActive(false);
            }
        }
    }
}
