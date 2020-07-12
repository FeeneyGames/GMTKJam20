using Godot;
using System;

public class Destructible : StaticBody2D
{
    public float destruction = 0;
    public const float DURABILITY = 5;
    private uint childCount = 0;
    private AnimationPlayer anim;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        anim = GetChild<AnimationPlayer>(0);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(childCount > 0)
        {
            destruction += delta;
            anim.Play("Destroying");
        }
        else if(destruction > 0)
        {
            destruction -= delta/3;
            anim.Play("Damaged");
        }
        if(destruction >= DURABILITY)
        {
            Globals.gameOver = true;
            anim.Play("Destroyed");
        }
        else if(destruction <= 0)
            anim.Play("Fixed");
    }

    private void _on_Area2D_body_entered(Node body)
    {
        if(body.GetParent().Name.Contains("Child"))
        {
            childCount += 1;
            body.GetParentOrNull<Child>().destroying = true;
        }
    }

    private void _on_Area2D_body_exited(Node body)
    {
        if(body.GetParent().Name.Contains("Child"))
        {
            childCount -= 1;
            body.GetParentOrNull<Child>().destroying = false;
        }
    }
}
