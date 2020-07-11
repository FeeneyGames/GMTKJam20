using Godot;
using System;

public class Child : Node2D
{
    public float speed = 2 * 25;
    public bool watched = false;
    private Mover mover;
    private float moveTimer = 0;
    private Vector2 prevDir = Vector2.Zero;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        mover = GetChild<Mover>(0);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        RandomMovement(delta);
    }

    private void RandomMovement(float delta)
    {
        moveTimer -= delta;
        if(moveTimer <= 0)
        {
            // Generate and apply direction
            Vector2 randomDir = RandomVec();
            if(mover.GetSlideCount() > 0)
                prevDir *= -1;
            float curSpeed = watched ? speed/2 : speed;
            mover.linearVelocity = curSpeed * (randomDir + (prevDir/2)).Normalized();
            // Update the state
            prevDir = (randomDir + (prevDir/2)).Normalized();
            moveTimer = (float)Godot.GD.RandRange(.5, 1.5);
        }
    }

    private Vector2 RandomVec()
    {
        return new Vector2((float)Godot.GD.RandRange(-1, 1), (float)Godot.GD.RandRange(-1, 1));
    }
}
