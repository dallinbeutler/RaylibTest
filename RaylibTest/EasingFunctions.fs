// Credit to lionliam96 for initial port
// t- Current Time
// b- start value 
// c- change in value
// d- duration

module EasingFunctions
open System

let inline private two() = LanguagePrimitives.GenericOne + LanguagePrimitives.GenericOne
let inline private three()= two + LanguagePrimitives.GenericOne
//let genericNum v = 


(*---------------------------- LINEAR ---------------------------*)
let inline LinearEase b c d t = (c*t/d+b)


//LanguagePrimitives.
(*----------------------------- QUAD ----------------------------*)
let inline QuadEaseIn b c d t=
    //(c*Math.Pow( (t/d), (2))+b)
    (c* (pown (t/d) (2))+b)
    

let inline QuadEaseOut b c d t=
    let td = t/d
    (-c*(td)*((td)+ -(two()))+b)
    

let inline QuadEaseInOut b c d t=
    let t = (t/d*two)
    let halfc = LanguagePrimitives.DivideByInt c 2    
    if (t < LanguagePrimitives.GenericOne) 
    then (halfc* (pown t 2)+b)
    else (-halfc*((t-LanguagePrimitives.GenericOne)*(t-three())-LanguagePrimitives.GenericOne)+b)        

let inline QuadEaseOutIn b c d t=
    let halfc = LanguagePrimitives.DivideByInt c 2
    let doublet = t* two()
    let qO = QuadEaseOut b (halfc) d
    let qI = QuadEaseIn (b+halfc) (halfc) d
    if (t < LanguagePrimitives.DivideByInt d 2) 
    then qO (doublet)
    else qI ((doublet)-d)
        

(*----------------------------- CUBIC ---------------------------*)
let inline CubicEaseIn b c d t =
    (c*(pown (t/d) 3)+b)
    
let inline CubicEaseOut b c d t=
    (c*((pown (t/d-LanguagePrimitives.GenericOne) 3)+LanguagePrimitives.GenericOne)+b)
    

let inline CubicEaseInOut b c d t=
    let t= t/d*two()
    if (t<LanguagePrimitives.GenericOne) then (c/two*t*t*t+b)
    else
        let t = t - two
        (c/two*(t*t*t+two)+b)

let inline CubicEaseOutIn b c d t=
    let cO = CubicEaseOut b (c/two) d
    let cI = CubicEaseIn (b+c/two) (c/two) d
    if (t<d/two) then cO (t*two)
    else cI ((t*two)-d)


(*----------------------------- QUART ---------------------------*)
let inline QuartEaseOut b c d t=
    let easeOut(t) = (-c*((pown t 4)-LanguagePrimitives.GenericOne)+b)
    easeOut(t/d-LanguagePrimitives.GenericOne)

let inline QuartEaseIn b c d t=
    let easeIn (t) = (c*(pown t 4)+b)
    easeIn(t/d)

let inline QuartEaseInOut b c d t=
    let easeInOut(t) =
        if (t < LanguagePrimitives.GenericOne) then (c/two*(pown t 4)+b)
        else
            let t = t - two()
            (-c/two*((pown t 4)-two())+b)
    easeInOut(t/d*two)

let inline QuartEaseOutIn b c d t=
    let qO = QuartEaseOut b (c/two) d
    let qI = QuartEaseIn (b+c/two) (c/two) d
    if (t < (d/two)) then qO (t*two)
    else qI ((t*two)-d)


(*----------------------------- QUINT ---------------------------*)
let inline QuintEaseOut b c d t=
    let easeOut(t) = (c*((pown t 5)+LanguagePrimitives.GenericOne)+b)
    easeOut(t/d-LanguagePrimitives.GenericOne)

let inline QuintEaseIn b c d t=
    let easeIn (t) = (c*(pown t 5)+b)
    easeIn(t/d)

let inline QuintEaseInOut b c d t=
    let easeInOut(t) =
        if (t < LanguagePrimitives.GenericOne) then (c/two*(pown t 5)+b)
        else
            let t = t - two()
            (-c/two()*((pown t 5)+two())+b)
    easeInOut(t/d*two())

let inline QuintEaseOutIn b c d t=
    let qO = QuintEaseOut b (c/two()) d
    let qI = QuintEaseIn (b+c/two()) (c/two()) d
    let easeOutIn (t) =
        if (t < (d/two())) then qO (t*two())
        else qI ((t*two())-d)
    easeOutIn(t)


(*----------------------------- SINE ---------------------------*)
let private halfPi = Math.PI /2.0

let inline SineEaseOut (b:^INumeric) c d t=
    (c*Math.Sin(t/d*(halfPi))+b)

let inline SineEaseIn b c d t=
    (-c*Math.Cos(t/d*(halfPi))+c+b)

let inline SineEaseInOut b c d t=
    (-c/two*(Math.Cos(Math.PI*t/d)-LanguagePrimitives.GenericOne)+b)

let inline SineEaseOutIn b c d t=
    let qO = QuintEaseOut b (c/two) d
    let qI = QuintEaseIn(b+c/two) (c/two) d
    if (t < (d/two)) then qO (t*two)
    else qI ((t*two)-d)


(*----------------------------- EXPO ----------------------------*)
let ExpoEaseIn b c d t=
    if (t.Equals 0) then b
    else (c*Math.Pow(2.0, (10.0*(t/d-1.0)))+b-c*0.001)

let ExpoEaseOut b c d t= 
    if (t.Equals d) then (b+c)
    else (c*1.001*(-Math.Pow(2.0, (-10.0*t/d))+1.0)+b)

let ExpoEaseInOut b c d t=
    if (t.Equals 0.0) then b
    else if (t.Equals d) then (b+c)
    else
        let t = t/d*2.0
        if (t<1.0) then (c/2.0*Math.Pow(2.0, (10.0*(t-1.0)))+b-c*0.0005)
        else
            let t = t - 1.0
            (c/2.0*1.0005*(-Math.Pow(2.0, (-10.0*t))+2.0)+b)

let ExpoEaseOutIn b c d t=
    let eO = ExpoEaseOut b (c/2.0) d
    let eI = ExpoEaseIn (b+c/2.0) (c/2.0) d
    
    if (t<(d/2.0)) then eO (t*2.0)
    else eI ((t*2.0)-d)


(*----------------------------- CIRC ----------------------------*)
let inline CircEaseIn b c d t=
  let easeIn (t) = (-c*( sqrt (LanguagePrimitives.GenericOne - (pown t 2))-LanguagePrimitives.GenericOne)+b)
  easeIn(t/d)

let inline CircEaseOut b c d t=
  let easeOut(t) = (c* sqrt (LanguagePrimitives.GenericOne-(pown t 2))+b)
  easeOut (t/d- LanguagePrimitives.GenericOne)

let inline CircEaseInOut b c d t=
  let easeInOut(t) =
      if (t<1.0) then (-c/2.0*(Math.Sqrt(1.0-t*t)-1.0)+b)
      else
          let t = t - 2.0
          (c/2.0*(Math.Sqrt(1.0-t*t)+1.0)+b)
  easeInOut(t/d*2.0)

let inline CircEaseOutIn b c d t=
  let halfc = LanguagePrimitives.DivideByInt c 2
  let cO = CircEaseOut b halfc d
  let cI = CircEaseIn(b+halfc) halfc d
  if (t<d/two()) then cO (t*two())
  else cI ((t*two())-d)


(*----------------------------- BACK ----------------------------*)
let inline BackEaseIn b c d s t=
    let s : double = 1.70158
    let easeIn (t) = (c*t*t*((s+LanguagePrimitives.GenericOne)*t-s)+b)
    easeIn(t/d)

let inline BackEaseOut b c d s t=
    let easeOut (t) = (c*(t*t*((s+LanguagePrimitives.GenericOne)*t+s)+LanguagePrimitives.GenericOne)+b)
    easeOut (t/d)

let inline BackEaseInOut b c d s t=
    let s = s * 1.525
    let easeInOut (t) =
        if (t > LanguagePrimitives.GenericOne) then (c/two()*(t*t*((s+LanguagePrimitives.GenericOne)*t-s))+b)
        else
            let t = t - two()
            (c/two*(t*t*((s+LanguagePrimitives.GenericOne)*t+s)+two())+b)
    easeInOut(t/d*two())

let inline BackEaseOutIn b c d s t=
    let bI = BackEaseIn (b+c/two()) (c/two()) d s
    let bO = BackEaseOut b (c/two()) d s    
    if (t<(d/two())) then bO (t*two())
    else bI (t*two)


(*---------------------------- BOUNCE ---------------------------*)
let inline BounceEaseOut b c d t=
    let easeOut(t) =
        if (t<(LanguagePrimitives.GenericOne/2.75)) then (c*(7.5625*t*t)+b)
        else if (t<(two()/2.75)) then
            let t = t-(1.5/2.75)
            (c*(7.5625*t*t+0.75)+b)
        else if (t<(2.5/2.75)) then
            let t = t-(2.25/2.75)
            (c*(7.5625*t*t+0.9375)+b)
        else
            let t = t-(2.625/2.75)
            (c*(7.5625*t*t+0.984375)+b)
    easeOut(t/d)

let inline BounceEaseIn b c d t=
    let bO = BounceEaseOut 0.0 c d
    (c-(bO (d-t))+b)

let inline BounceEaseInOut b c d t=
    let bO = BounceEaseOut 0.0 c d
    let bI = BounceEaseIn 0.0 c d
    fun (t) ->
        if (t<(d/two)) then (bI (t*two)*0.5+b)
        else (bO (t*two-d)*0.5+c*0.5+b)

let inline BounceEaseOutIn b c d t=
    let bO = BounceEaseOut b (c/two) d
    let bI = BounceEaseIn (b+c/two) (c/two) d
    fun (t) ->
        if (t<(d/two)) then bO (t*two) else bI (t*two-d)
