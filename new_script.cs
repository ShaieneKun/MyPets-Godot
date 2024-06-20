using Godot;
using System;

public partial class new_script : Node
{
	private int frameCount = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Godot.GD.Print("Hello, World!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.frameCountIncrement();
		Godot.GD.Print("Current frame: " + getFrameCount());
	}

	private int getFrameCount()
	{
		return this.frameCount;
	}

	private void frameCountIncrement()
	{
		this.frameCount++;
	}
}
