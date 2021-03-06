using Godot;
using System;

public class Eye : Node2D
{

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseMode.Hidden);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        this.Position = GetGlobalMousePosition();
    }

    private void _on_Area2D_body_entered(Node body)
    {
        if(body.GetParent().Name.Contains("Child"))
            body.GetParentOrNull<Child>().mover.speedMultiplier = .333f;
    }

    private void _on_Area2D_body_exited(Node body)
    {
        if(body.GetParent().Name.Contains("Child"))
            body.GetParentOrNull<Child>().mover.speedMultiplier = 1;
    }
}
