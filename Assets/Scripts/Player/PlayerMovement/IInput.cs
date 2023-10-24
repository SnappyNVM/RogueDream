using System;
using UnityEngine;

public interface IInput
{
    public event Action<Vector2> MouseButtonDown;
    public event Action<Vector2> MouseButtonUp;
    public event Action<Vector2> Move;
    public bool InteractiveButtonPressed { get; }

    public Vector2 MovingDirection { get; }
    public bool IsMoving => MovingDirection != Vector2.zero;
}
