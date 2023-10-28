using System;
using UnityEngine;

public class InputHandler : IDisposable
{
    private IInput _input;
    private Player _player;
    
    public Vector3 MousePosition => _input.MousePosition;
    public bool IsMoving => _input.IsMoving;
    public bool IsInteractiveButtonPressed => _input.InteractiveButtonPressed;

    public InputHandler(IInput input, Player player)
    {
        _input = input;
        _player = player;
        _input.MouseButtonDown += OnMouseDown;
        _input.MouseButtonUp += OnMouseUp;
        _input.Move += OnMove;
        _input.InteractiveButtonUp += OnInteractiveButtonUp;
    }

    public void Dispose()
    { 
        _input.MouseButtonDown -= OnMouseDown;
        _input.MouseButtonUp -= OnMouseUp;
        _input.Move -= OnMove;
        _input.InteractiveButtonUp -= OnInteractiveButtonUp;
    }

    private void OnMouseDown(Vector2 mousePosition)
    {

    }

    private void OnMouseUp(Vector2 mousePosition)
    {

    }

    private void OnInteractiveButtonUp() =>
        _player.ItemPickuper.ChangeItemPressFlagToFalse();

    private void OnMove(Vector2 deltaMove) =>
        _player.Rigidbody.MovePosition(_player.Rigidbody.position + deltaMove.normalized * _player.PlayerConfig.Speed * Time.deltaTime);
}
