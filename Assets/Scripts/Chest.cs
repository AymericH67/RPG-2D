using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] graphisme;
    [SerializeField] private Sprite[] openSprite;
    [SerializeField] private Sprite[] cloeSprite;

    private bool isReatch = false;
    private bool open = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
    }
}
