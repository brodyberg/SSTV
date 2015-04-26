// http://mark-dot-net.blogspot.com/2009/10/playback-of-sine-wave-in-naudio.html

#I @"..\packages\NAudio.1.7.3\lib\net35\"
#r "NAudio.dll"

open NAudio
open NAudio.Wave

let readFloat (x:(float32 array * int)) = -1

// definition: WaveStream: class that implements IWaveProvider

//let x = NAudio.Wave.WaveProvider32(44100, 1)

let SetWaveFormat((sampleRate:int),(channels:int)) = ()

//type SineWaveProvider32((frequency:int),(amplitude:float)) =
type SineWaveProvider32() = 
    inherit WaveProvider32()

    let frequency = 1000
    let amplitude = 0.25f

    with 
        member this.Frequency = frequency
        member this.Amplitude = amplitude

//        override this.Read(x:((float32 array)*(y:int)*(z:int))) = -1
        override this.Read(x:(float32 array) * int * int) = -1
//        override this.Read(x:(float array * int * int)) = -1

//    let waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels);
//    let waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1)

//     override this.WaveFormat = waveFormat
    // override this.SetWaveFormat((sampleRate:int),(channels:int)) = ()


//    override this.SetWaveFormat((sampleRate:int),(channels:int)) = ()
//    override this.Read (x:(byte array * int * int)) = -3
    //override this.Read (y:(float array * int * int)) = -4

//let sineWaver = SineWaveProvider32(1000, 25f)
//
//let second (sampleRate,channels) =
//    { new WaveProvider32((sampleRate:int),(channels:int))
//      with
////        member this.Read(x:(float array * int * int) = -1
//          member this.Read(buffer,offset,count) = -1
//          // member this.Read(buffer,offset,count) = 
// 
//        
//    
//    
//      }

let makeSound (sampleRate:int) (channels:int) = 
    { new NAudio.Wave.IWaveProvider

      with 
          member this.Read(buffer,offset,count) = 
            let wb = WaveBuffer(buffer)
            let samplesRequired = count / 4
            let samplesRead = readFloat(wb.FloatBuffer, offset / samplesRequired)
    
            samplesRead * 4
             
          member this.WaveFormat with get() = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate,channels) }

let x = makeSound 44100 1 

x.WaveFormat
