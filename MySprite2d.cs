using Godot;
// using System;

public partial class MySprite2d : Sprite2D
{
    private int _speed = 500;
    private float _angularSpeed = Mathf.Pi;

    public override void _Process(double delta)
    {
        // playerAutoMovementRotation(delta);
        playerMovementTankControls(delta);
    }

    /// <summary>
    /// This function is part of the Godot tutorial
    /// </summary>
    /// <param name="delta">Delta given to the _Process method</param>
    private void playerAutoMovementRotation(double delta)
    {
        Rotation += _angularSpeed * (float)delta;
        Vector2 velocity = Vector2.Up.Rotated(Rotation) * _speed;

        Position += velocity * (float)delta;
    }

    /// <summary>
    /// This function is part of the Godot tutorial
    /// </summary>
    /// <param name="delta">Delta given to the _Process method</param>
    private void playerMovementTankControls(double delta)
    {
        int direction = 0;
        string directionText = "";
        Vector2 velocity = Vector2.Zero;

        if (Input.IsActionPressed("ui_up"))
        {
            velocity = Vector2.Up.Rotated(Rotation) * _speed;
            directionText = "Uo Key";
        }

        if (Input.IsActionPressed("ui_down"))
        {
            velocity = Vector2.Up.Rotated(Rotation) * _speed * -1;
            directionText = "Down Key";
        }

        if (Input.IsActionPressed("ui_left"))
        {
            direction = -1;
            directionText = "Left Key";
        }
        if (Input.IsActionPressed("ui_right"))
        {
            direction = 1;
            directionText = "Right Key";
        }

        if (direction != 0 || velocity != Vector2.Zero)
            GD.Print($"Pressed Key: {directionText}");

        Rotation += _angularSpeed * direction * (float)delta;
        Position += velocity * (float)delta;
    }

    private void OnButtonPressed()
    {
        GD.Print("Button Pressed!");
        SetProcess(!IsProcessing());
    }
}
