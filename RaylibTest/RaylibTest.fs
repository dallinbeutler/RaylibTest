module RaylibTest
open Raylib

let mainloop () =
  RL.BeginDrawing();
  RL.ClearBackground(Color.WHITE);
  RL.BeginMode3D(Camera.camera)

  BasicMap.DrawScene(Camera.camera)
  
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
