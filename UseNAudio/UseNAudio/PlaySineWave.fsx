// http://mark-dot-net.blogspot.com/2009/10/playback-of-sine-wave-in-naudio.html

#I @"..\packages\NAudio.1.7.3\lib\net35\"
#r "NAudio.dll"

open NAudio
open NAudio.Wave

let readFloat (x:(float32 array * int)) = -1

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
