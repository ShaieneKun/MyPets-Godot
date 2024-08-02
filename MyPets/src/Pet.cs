using Godot;
using System;

public partial class Pet : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// _PetMovement();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _PetMovement()
	{
		AnimatedSprite2D animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D2");
		string[] petTypes = animatedSprite2D.SpriteFrames.GetAnimationNames();

		animatedSprite2D.Play(petTypes[GD.Randi() % petTypes.Length]);
	}

	// Signals
	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}
}
