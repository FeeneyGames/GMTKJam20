using Godot;
using System;

public class Parent : Node2D
{
    public float speed = 5 * 25;
    public bool carrying = false;
    private Vector2 babyOffset = new Vector2(0, 37.5f);
    private Mover mover;
    private RayCast2D rayCast;
    private PackedScene childScene = (PackedScene)GD.Load("res://Actors/Child.tscn");

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        mover = GetChild<Mover>(0);
        rayCast = ((Node2D)mover).GetChild<RayCast2D>(0);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        InputMovement();
        InputCarry();
    }

    // Handles the movement from player input
    private void InputMovement()
    {
        Vector2 dir = new Vector2();
        if(Input.IsActionPressed("ui_right"))
        {
            dir += Vector2.Right;
        }
        if(Input.IsActionPressed("ui_left"))
        {
            dir += Vector2.Left;
        }
        if(Input.IsActionPressed("ui_up"))
        {
            dir += Vector2.Up;
        }
        if(Input.IsActionPressed("ui_down"))
        {
            dir += Vector2.Down;
        }
        mover.linearVelocity = speed * dir.Normalized();
    }

    // Handles carry or drop inputs
    private void InputCarry()
    {
        if(Input.IsActionJustPressed("ui_select"))
        {
            if(carrying)
            {
                rayCast.ForceRaycastUpdate();
                if(rayCast.IsColliding() == false)
                {
                    Node2D newChild = (Node2D)childScene.Instance();
                    newChild.Position = this.Position + mover.Position + babyOffset;
                    GetParent().AddChild(newChild);
                    carrying = false;
                }
            }
            else
            {
                for(int i = 0; i < mover.GetSlideCount(); i++)
                {
                    KinematicCollision2D collision = mover.GetSlideCollision(i);
                    Node2D collider = (Node2D)collision.Collider;
                    if(collider.Name == "Mover")
                    {
                        collider.GetParent().Free();
                        carrying = true;
                        break;
                    }
                }
            }
        }
    }
}
