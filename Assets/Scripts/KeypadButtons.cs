using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButtons : HoverBase
{
    private string _input;

    protected override void Awake()
    {
        base.Awake();

        _input = gameObject.name.Substring(gameObject.name.Length - 1);
    }

    protected override void OnMouseDown()
    {
        SendMessageUpwards("ButtonPressed",_input);
    }
}
