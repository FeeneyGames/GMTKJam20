using Godot;
using System;

public class Pathfinding : Navigation2D
{
    private Node2D destructibles;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        destructibles = GetChildOrNull<Node2D>(0);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }

    public Vector2[] GetChildPath(Vector2 childPos)
    {
        int objInd = (int)(GD.Randi() % ((uint)destructibles.GetChildCount()));
        Vector2[] path = GetSimplePath(childPos, destructibles.GetChildOrNull<Node2D>(objInd).GlobalPosition);
        for(int i = 0; i < path.Length; i++)
            path[i] = ToGlobal(path[i]);
        return path;
    }
}
