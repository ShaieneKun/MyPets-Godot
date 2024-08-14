using Godot;
using System;

public partial class Pet : RigidBody2D
{
	[Export]
	public int Speed { get; set; } = 15; // How fast the player will move (pixels/sec).

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// _PetMovement();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_PetMovement(delta);
	}

	private void _PetMovement(double delta)
	{
		// AnimatedSprite2D pet = GetNode<AnimatedSprite2D>("AnimatedSprite2D2");
		int direction = 0;
		Vector2 velocity = Vector2.Down;

		Position += velocity * Speed * (float)delta;

		// string[] petTypes = animatedSprite2D.SpriteFrames.GetAnimationNames();

		// animatedSprite2D.Play(petTypes[GD.Randi() % petTypes.Length]);
		// pet.Position
	}

	// Signals
	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		GD.Print("Out of screen");
		QueueFree();
	}
}
