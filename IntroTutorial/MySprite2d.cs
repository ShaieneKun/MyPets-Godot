using Godot;
// using System;

public partial class MySprite2d : Sprite2D
{
    private int _speed = 500;
    private int _health = 10;

    private float _angularSpeed = Mathf.Pi;

    // _Ready and _Signal

    public override void _Ready()
    {
        Timer timer = GetNode<Timer>("Timer");
        timer.Timeout += OnTimerTimeout;
    }

    public override void _Process(double delta)
    {
        playerAutoMovementRotation(delta);
        // playerMovementTankControls(delta);
    }

    // _Process functions

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

    // Signals Callbacks

    private void OnButtonPressed()
    {
        GD.Print("Button Pressed!");
        SetProcess(!IsProcessing());
    }

    private void OnTimerTimeout()
    {
        Visible = !Visible;
        TakeDamage(1);
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        if (_health <= 9)
        {
            EmitSignal(SignalName.HealthDepleted);
        }
    }

    // Signals

    [Signal]
    public delegate void HealthDepletedEventHandler();

}
