using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    [SerializeField] private Item[] content;

    [SerializeField] private SpriteRenderer[] graphisme;
    [SerializeField] private Sprite[] openSprite;
    [SerializeField] private Sprite[] cloeSprite;
    [SerializeField] private GameObject openTxt;

    private GameManager manager;

    private InputAction interactAction;

    [SerializeField] private bool isReatch = false;
    [SerializeField] private bool open = false;

    private void Start()
    {
        manager = GameManager.GetInstance();
        interactAction = manager.GetInput().actions.FindAction("Interact");
        openTxt.gameObject.SetActive(false);
    }

    private void Update()
    {
        float _interact = interactAction.ReadValue<float>();

        if(isReatch && _interact > 0)
        {
            ChanceState(true, openSprite);
        }
        else if (!isReatch)
        {
            ChanceState(false, cloeSprite);
        }
    }

    private void ChanceState(bool _state, Sprite[] _sprites)
    {
        open = _state;
        if(open) EmptyChest();

        for (int i = 0; i < graphisme.Length; i++) // pour chaque sprite renderer
        {
            graphisme[i].sprite = _sprites[i];
        }
    }

    private void EmptyChest()
    {
        foreach(var _item in content)
        {
            CharactersInfoes.AddItem(_item.id, _item.number);
            _item.number = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReatch = true;
            openTxt.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReatch = false;
            openTxt.gameObject.SetActive(false);
        }
    }
}
