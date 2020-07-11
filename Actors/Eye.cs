using Godot;
using System;

public class Eye : Node2D
{
    private AnimationPlayer animPlayer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animPlayer = GetChildOrNull<AnimationPlayer>(0);
        Input.SetMouseMode(Input.MouseMode.Hidden);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        this.Position = GetGlobalMousePosition();
    }

    private void _on_Area2D_body_entered(Node body)
    {
        if(body.GetParent().Name.BeginsWith("Child"))
            body.GetParentOrNull<Child>().watched = true;
    }

    private void _on_Area2D_body_exited(Node body)
    {
        if(body.GetParent().Name.BeginsWith("Child"))
            body.GetParentOrNull<Child>().watched = false;
    }
}
