using System;
using UnityEngine;

public interface IInput
{
    public event Action<Vector2> MouseButtonDown;
    public event Action<Vector2> MouseButtonUp;
    public event Action<Vector2> Move;
    public event Action InteractiveButtonUp;

    public bool InteractiveButtonPressed { get; }
    public virtual bool IsMoving => MovingDirection != Vector2.zero;

    public Vector2 MovingDirection { get; }
    public Vector3 MousePosition { get; }
}
