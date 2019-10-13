module Camera
open Raylib.Raylib
open Raylib

let mutable camera = 
  new Camera3D(
    new Vector3( 0.0f, 10.0f, 10.0f )
    , new Vector3( 0.0f, 0.0f, 0.0f )
    , new Vector3( 0.0f, 1.0f, 0.0f )
    , 10.0f
    , CameraType.CAMERA_ORTHOGRAPHIC )

let mutable moveSpeed = 0.5f

// Define the camera to look into our 3d world
//RL.SetCameraMode(camera, CameraMode.CAMERA_CUSTOM)


let updatePos ()=
  
  let mutable newTarget =  Vector3()
  if RL.IsKeyDown(KeyboardKey.KEY_W) 
  then newTarget.z <-newTarget.z - 0.1f
  if RL.IsKeyDown(KeyboardKey.KEY_S) 
  then newTarget.z <-newTarget.z + 0.1f
  if RL.IsKeyDown(KeyboardKey.KEY_D) 
  then newTarget.x <-newTarget.x + 0.1f
  if RL.IsKeyDown(KeyboardKey.KEY_A) 
  then newTarget.x <-newTarget.x - 0.1f
  
  RL.SetCameraSmoothZoomControl(KeyboardKey.KEY_B)

  let onlyzx = (Vector3.One - Vector3.UnitY )
  
  let relative = (RL.Vector3Transform(newTarget,RL.GetMatrixModelview()) * onlyzx)
  let relative = RL.Vector3Normalize(relative)
  let relative = relative * moveSpeed
  //let look =   
  //  |> QuaternionNormalize
  //  |> QuaternionToEuler

  
  //let look = Raylib.Vector3Normalize( look * onlyzx) 
  
  //let adjusted = look * newTarget
  camera.position<- camera.position + relative// + adjusted//(newTarget)
  camera.target <- camera.target + relative//+ adjusted//newTarget
  camera.up
  