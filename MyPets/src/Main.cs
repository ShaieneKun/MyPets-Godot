using Godot;
using System;

public partial class Main : Node
{
	[Export]
	public PackedScene PetScene { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void GameOver()
	{
		GetNode<Timer>("Timers/PetTimer").Stop();
		GetNode<Timer>("Timers/ScoreTimer").Stop();

		GetNode<HUD>("HUD").ShowGameOver();
		// Note that for calling Godot-provided methods with strings,
		// we have to use the original Godot snake_case name.
		GetTree().CallGroup("Pets", Node.MethodName.QueueFree);
		GetNode<AudioStreamPlayer2D>("Music").Stop();
		GetNode<AudioStreamPlayer2D>("DeathSound").Play();
	}

	public void NewGame()
	{
		var hud = GetNode<HUD>("HUD");
		hud.Hide();
		Pet pet = PetScene.Instantiate<Pet>();
		AddChild(pet);
	}

	private void OnPetTimerTimeout()
	{
		// Note: Normally it is best to use explicit types rather than the `var`
		// keyword. However, var is acceptable to use here because the types are
		// obviously Pet and PathFollow2D, since they appear later on the line.

		// Create a new instance of the Pet scene.
		Pet pet = PetScene.Instantiate<Pet>();

		// Choose a random location on Path2D.
		PathFollow2D PetSpawnLocation = GetNode<PathFollow2D>("Positions/PetPath/PetSpawnLocation");
		PetSpawnLocation.ProgressRatio = GD.Randf();

		// Set the Pet's direction perpendicular to the path direction.
		float direction = PetSpawnLocation.Rotation + Mathf.Pi / 2;

		// Set the Pet's position to a random location.
		pet.Position = PetSpawnLocation.Position;

		// Add some randomness to the direction.
		direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		pet.Rotation = direction;

		// Choose the velocity.
		Vector2 velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
		pet.LinearVelocity = velocity.Rotated(direction);

		// Spawn the Pet by adding it to the Main scene.
		AddChild(pet);
	}
}
