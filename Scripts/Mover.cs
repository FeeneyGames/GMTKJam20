using Godot;
using System;

public class Mover : KinematicBody2D
{
    public Vector2 linearVelocity = Vector2.Zero;
    private Vector2 prevVelocity = Vector2.Zero;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        // Averaging velocity vectors helps stop stuttering
        MoveAndSlide((linearVelocity + prevVelocity)/2);
        prevVelocity = linearVelocity;
    }
}
