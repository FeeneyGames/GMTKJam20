using Godot;
using System;

public class Child : Node2D
{
    public float speed = 3 * 25;
    public const float SPEED_RATE = .25f;
    public const float PATH_TIMER_MAX = 10;
    public bool destroying = false;
    public Mover mover;
    private Vector2[] path;
    private uint pathInd = 0;
    private float moveTimer = 0;
    private float pathTimer = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        mover = GetChild<Mover>(0);
        NewPath();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // Update path target
        if((mover.GlobalPosition - path[pathInd]).Length() < 25)
        {
            pathInd += 1;
            if(pathInd >= path.Length)
            {
                NewPath();
            }
        }
        // Get new path if current one times out
        pathTimer -= delta;
        if(pathTimer <= 0)
            NewPath();
        // Slowly increase speed
        speed += delta * SPEED_RATE;
        RandomMovement(delta);
    }

    private void RandomMovement(float delta)
    {
        moveTimer -= delta;
        if(destroying)
            mover.linearVelocity = Vector2.Zero;
        else if(moveTimer <= 0)
        {
            // Generate and apply direction
            Vector2 randomDir = RandomVec();
            Vector2 pathDir = (path[pathInd] - mover.GlobalPosition).Normalized();
            mover.linearVelocity = speed * (mover.GetSlideCount() > 0 ? randomDir : (pathDir + randomDir)).Normalized();
            // Update the state
            moveTimer = (float)Godot.GD.RandRange(.5, 1);
        }
    }

    private void NewPath()
    {
        path = GetParent().GetChildOrNull<Pathfinding>(0).GetChildPath(mover.GlobalPosition);
        pathInd = 0;
        pathTimer = PATH_TIMER_MAX;
    }

    private Vector2 RandomVec()
    {
        return new Vector2((float)Godot.GD.RandRange(-1, 1), (float)Godot.GD.RandRange(-1, 1));
    }
}
