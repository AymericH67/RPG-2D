using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMotor : MonoBehaviour
{
    [SerializeField]
    private PlayerInput input;
    private InputAction moveAction;

    private Animator anim;

    private GameManager manager;

    private Vector2 velocity = Vector2.zero;
    private int direction = 0;
    private float speed = 5f;

    void Start()
    {
        manager = GameManager.GetInstance();
        input = manager.GetInput();
        anim = GetComponent<Animator>();

        moveAction = input.actions.FindAction("Move");
    }

    void FixedUpdate()
    {
       Vector2 _moveValue = moveAction.ReadValue<Vector2>();
        _moveValue = ChooseDirection(_moveValue);

        velocity = _moveValue * speed;

        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0);

        // Animation
        anim.SetInteger("direction", direction);
    }

    private Vector2 ChooseDirection(Vector2 _value)
    {
        Vector2 _result = Vector2.zero;

        if (Mathf.Abs(_value.x) >= Mathf.Abs(_value.y))
        {
            _result = new Vector2(_value.x, 0);
        }
        else
        {
            _result = new Vector2(0, _value.y);
        }

        direction = SetDirection(_result);
        return _result;
    }

    private int SetDirection(Vector2 _vector)
    {
        if (_vector.x > 0)
        {
            return 6;
        }

        if (_vector.x < 0)
        {
            return 4;
        }

        if (_vector.y > 0)
        {
            direction = 8;
        }
        if (_vector.y < 0)
        {
            direction = 2;
        }

        return 0;
    }
}