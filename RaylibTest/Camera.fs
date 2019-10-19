module Camera
open Raylib.Raylib
open Raylib

let mutable camera = 
  new Camera3D(
    new Vector3( -100.0f, 100.0f, 100.0f )
    , new Vector3( 0.0f, 0.0f, 0.0f )
    , new Vector3( 0.0f, 1.0f, 0.0f )
    , 10.0f
    , CameraType.CAMERA_ORTHOGRAPHIC )

let mutable moveSpeed = 0.5f

// Define the camera to look into our 3d world
//RL.SetCameraMode(camera, CameraMode.CAMERA_CUSTOM)

type Direction =
|Forward
|Back
|Left
|Right
|Nop

let mappings =
  [|
  (KeyboardKey.KEY_W, Forward)
  (KeyboardKey.KEY_A, Left)
  (KeyboardKey.KEY_S, Back)
  (KeyboardKey.KEY_D, Right)
  |]

let getActions mappings =
  mappings |> Array.choose(fun x-> if RL.IsKeyDown(fst x) then Some (snd x) else None)


let handleMovement (d:Direction)=
  match d with
  |Forward -> Vector3(1.0f,0.0f,0.0f)
  |Back-> Vector3(-1.0f,0.0f,0.0f)
  |Left-> Vector3(0.0f,0.0f,1.0f)
  |Right-> Vector3(0.0f,0.0f,-1.0f)
  |Nop-> Vector3()


let handleMappings keymaps =
  keymaps
  |> getActions
  |> Array.fold(fun movement act ->movement + (handleMovement act)) (Vector3())

let private onlyzx = (Vector3.One - Vector3.UnitY )

let toCamSpace() = RL.MatrixInvert(RL.GetMatrixModelview())

type MovementRelative =
|Screen
|World
let AdjustForCamera (mr: MovementRelative) (v:Vector3) = // (m:MovementRelative) =
  //let r = QuaternionFromVector3ToVector3(Vector3(), Vector3.One - Vector3.UnitY)
  //let r = QuaternionFromVector3ToVector3(Vector3(), Vector3.One)
  
  let r = QuaternionFromAxisAngle(Vector3.UnitY, 90.0f)
  let v = (RL.Vector3Transform(v, (RL.GetMatrixModelview()) )  )
  let v = match mr with
  |World-> v
  |Screen -> v//Vector3RotateByQuaternion(v,r)
  RL.Vector3Normalize(v * onlyzx)
  
  
  
let updatePos ()=
  
  let newTarget =
    handleMappings mappings
    |> AdjustForCamera Screen
  //RL.SetCameraSmoothZoomControl(KeyboardKey.KEY_B)
  
  
  //let relative = (RL.Vector3Transform(newTarget,RL.GetMatrixModelview()) )
  //let rot = QuaternionFromEuler(0.0f,90.0f,0.0f)
  //let rotated = Vector3RotateByQuaternion(relative,rot)
  //let relative = RL.Vector3Normalize(relative * onlyzx)
  let relative = newTarget * moveSpeed
  //let look =   
  //  |> QuaternionNormalize
  //  |> QuaternionToEuler

  
  //let look = Raylib.Vector3Normalize( look * onlyzx) 
  
  //let adjusted = look * newTarget
  camera.position<- camera.position + relative// + adjusted//(newTarget)
  camera.target <- camera.target + relative//+ adjusted//newTarget
  camera.fovy <- camera.fovy + (float32 (-RL.GetMouseWheelMove()))


  let sw =RL.GetScreenWidth()
  let sh =RL.GetScreenHeight()
  let scrollZoneX = sw/10
  let scrollZoneY = sw/10
  let mp = RL.GetMousePosition() 
  //if 

  

  ()
