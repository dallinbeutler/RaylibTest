module BasicMap

open Raylib

let myGizmo mat drawFunc= 
  let mmv = RL.GetMatrixModelview()
  RL.SetMatrixModelview(mat)
  drawFunc
  RL.SetMatrixModelview(mmv)


let DrawScene( cam:Camera3D)= 
  RL.DrawCube(new Vector3(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, Color.RED);
  RL.DrawCubeWires(new Vector3(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, Color.GOLD);
  RL.DrawCubeWires(new Vector3(-4.0f, 0.0f, -2.0f), 3.0f, 6.0f, 2.0f, Color.MAROON);
  RL.DrawSphere(new Vector3(-10.0f, 0.0f, -2.0f), 1.0f, Color.GREEN);
  RL.DrawSphereWires(new Vector3(10.0f, 0.0f, 2.0f), 2.0f, 16, 16, Color.LIME);
  RL.DrawCylinder(new Vector3(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, Color.SKYBLUE);
  RL.DrawCylinderWires(new Vector3(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, Color.DARKBLUE);
  RL.DrawCylinderWires(new Vector3(4.5f, -1.0f, 2.0f), 1.0f, 1.0f, 2.0f, 6, Color.BROWN);
  RL.DrawCylinder(new Vector3(10.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, Color.GOLD);
  RL.DrawCylinderWires(new Vector3(10.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, Color.PINK);
  RL.DrawCube(RL.Vector3Transform(Vector3(1.0f,0.0f,1.0f),RL.GetCameraMatrix(cam)),10.0f,1.0f,1.0f,Color.RED)
  RL.DrawCube(RL.Vector3Transform(Vector3(1.0f,0.0f,0.0f),RL.GetCameraMatrix(cam)),10.0f,1.0f,1.0f,Color.RED)
  RL.DrawCube(RL.Vector3Transform(Vector3(0.0f,0.0f,1.0f),RL.GetCameraMatrix(cam)),10.0f,1.0f,1.0f,Color.RED)
  RL.DrawCube(RL.Vector3Transform(Vector3(0.0f,0.0f,0.0f),RL.GetCameraMatrix(cam)),10.0f,1.0f,1.0f,Color.RED)  
  RL.DrawCube(RL.Vector3Transform(Vector3(0.0f,1.0f,0.0f),RL.GetCameraMatrix(cam)),10.0f,1.0f,1.0f,Color.RED)  
  let trythis = RL.MatrixInvert(RL.GetMatrixModelview()) 
  RL.DrawCube(RL.Vector3Transform(Vector3(0.0f,1.0f,0.0f),trythis),1.0f,1.0f,1.0f,Color.BLUE)  
  let try2 = RL.MatrixMultiply(  trythis,RL.MatrixInvert( RL.MatrixIdentity()) )
  RL.DrawCube(RL.Vector3Transform(Vector3(0.0f,1.0f,0.0f), try2),1.0f,1.0f,1.0f,Color.GREEN)  
  myGizmo trythis (RL.DrawCube(Vector3(),2.0f,1.0f,1.0f,Color.BLACK) )
  RL.DrawGizmo(Vector3.UnitY)
  RL.DrawGrid(100,1.0f)
  
//type 