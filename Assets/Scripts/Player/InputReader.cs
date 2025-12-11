using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode ButtonD = KeyCode.D;
    private const KeyCode ButtonA = KeyCode.A;
    private const KeyCode ButtonSpace = KeyCode.Space;
    private const KeyCode ButtonMouse0 = KeyCode.Mouse0;

    public event Action<float> Movable;
    public event Action Jumper;
    public event Action Idled;
    public event Action Attacked;

    private readonly string _horizontal = "Horizontal";

    private void Update()
    {
        var horizontalX = Input.GetAxis(_horizontal);

        if (Input.GetKey(ButtonD))
            Movable?.Invoke(horizontalX);
        else if (Input.GetKey(ButtonA))
            Movable?.Invoke(horizontalX);
        else
            Idled?.Invoke();

        if (Input.GetKeyDown(ButtonSpace))
            Jumper?.Invoke();

        if (Input.GetKeyDown(ButtonMouse0))
            Attacked?.Invoke();
    }
}
