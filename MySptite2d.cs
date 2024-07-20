using Godot;
// using System;

public partial class MySptite2d : Sprite2D
{
    private int _speed = 1;
    private float _angularSpeed = Mathf.Pi;

    public override void _Process(double delta)
    {
        Rotation += _speed * (float)delta;
    }
}
