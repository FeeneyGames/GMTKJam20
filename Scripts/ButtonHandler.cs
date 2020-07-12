using Godot;
using System;

public class ButtonHandler : Control
{
    private LevelHandler levelHandler;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseMode.Visible);
        levelHandler = GetNode<LevelHandler>("/root/LevelHandler");
    }

    public void _on_Button_pressed(int index)
    {
        levelHandler.ChangeLevel(index);
    }
}
