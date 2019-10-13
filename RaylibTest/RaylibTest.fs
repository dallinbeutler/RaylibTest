module RaylibTest
open Raylib

let mainloop () =
  RL.BeginDrawing();
  RL.ClearBackground(Color.WHITE);
  RL.BeginMode3D(Camera.camera)

  RL.DrawCube(new Vector3(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, Color.RED);
  RL.DrawCubeWires(new Vector3(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, Color.GOLD);
  RL.DrawCubeWires(new Vector3(-4.0f, 0.0f, -2.0f), 3.0f, 6.0f, 2.0f, Color.MAROON);
  RL.DrawSphere(new Vector3(-1.0f, 0.0f, -2.0f), 1.0f, Color.GREEN);
  RL.DrawSphereWires(new Vector3(1.0f, 0.0f, 2.0f), 2.0f, 16, 16, Color.LIME);
  RL.DrawCylinder(new Vector3(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, Color.SKYBLUE);
  RL.DrawCylinderWires(new Vector3(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, Color.DARKBLUE);
  RL.DrawCylinderWires(new Vector3(4.5f, -1.0f, 2.0f), 1.0f, 1.0f, 2.0f, 6, Color.BROWN);
  RL.DrawCylinder(new Vector3(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, Color.GOLD);
  RL.DrawCylinderWires(new Vector3(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, Color.PINK);
  RL.DrawGizmo(Vector3())
  RL.DrawGrid(100,1.0f)
  
  RL.EndMode3D()
  RL.DrawText("Hello, world!", 102, 102, 20, Color.BLACK);  
  RL.DrawFPS(10,10)
  
  RL.EndDrawing();
  Camera.updatePos()
  RL.UpdateCamera(&Camera.camera)

[<EntryPoint>]
let main argv =
    RL.InitWindow(640,480, "Hello Raylib!")

    RL.SetTargetFPS(60)   // Set our game to run at 60 frames-per-second
    
    while not (RL.WindowShouldClose())
      do mainloop()

    printfn "%A" argv
    0 // return an integer exit code
