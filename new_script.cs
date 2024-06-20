using Godot;
using System;

public partial class new_script : Node
{
	private int frameCount = 0;
	private Label _label;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Godot.GD.Print("Hello, World!");
		_label = GetNode<Label>("Camera2D/Label");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.frameCountIncrement();

		string currentFrame = "Current frame: " + getFrameCount();
		Godot.GD.Print(currentFrame);

		_label.Text = "Hello World!\n" + currentFrame;
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
