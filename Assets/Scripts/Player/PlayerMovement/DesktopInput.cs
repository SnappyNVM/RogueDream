using System;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class DesktopInput : IInput, IFixedTickable, ITickable
{
    private bool _interactiveButtonPressed;
    private Vector2 _framePositionChanges;

    public event Action<Vector2> MouseButtonDown;
    public event Action<Vector2> MouseButtonUp;
    public event Action<Vector2> Move;
    public bool InteractiveButtonPressed => _interactiveButtonPressed;


    public bool IsMoving => MovingDirection != Vector2.zero;
    public Vector2 MovingDirection => _framePositionChanges;

    public void Tick()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
            MouseButtonDown.Invoke(Input.mousePosition);

        if (Input.GetMouseButtonUp((int)MouseButton.LeftMouse))
            MouseButtonUp.Invoke(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.E))
            _interactiveButtonPressed = true;

        if (Input.GetKeyUp(KeyCode.E))
            _interactiveButtonPressed = false;
    }

    public void FixedTick()
    {
        _framePositionChanges = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (_framePositionChanges.sqrMagnitude != 0)
            Move.Invoke(_framePositionChanges);
    }
}