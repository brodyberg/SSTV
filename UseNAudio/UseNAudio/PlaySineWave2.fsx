#I @"..\packages\NAudio.1.7.3\lib\net35\"
#r "NAudio.dll"

open System
open NAudio
open NAudio.Wave

type SineWaveProvider32() =
    inherit NAudio.Wave.WaveProvider32()

    let frequency = 1000.0
    let amplitude = 0.25

    let mutable sample = 0.0

    let sin32 a = (float32) (System.Math.Sin a)
    let iterateAndCapSample sampleRate =
        sample <- sample + 1.0

        if sample >= (float) sampleRate
        then sample <- 0.0

    member this.Frequency = frequency
    member this.Amplitude = amplitude
    override this.Read(buffer:float32 [], offset:int, sampleCount:int) =
        let sampleRate = base.WaveFormat.SampleRate

        // Fold across simple sequence, so there's no mutation of sample
        seq { for i in 0 .. sampleCount -> 
                iterateAndCapSample sampleRate
                sin32 (2.0 * Math.PI * sample * this.Frequency)
            }
        |> Seq.iteri (fun i item -> buffer.[i+offset] <- (float32) item)

        sampleCount

let sineWaveProvider = SineWaveProvider32()
sineWaveProvider.SetWaveFormat(16000, 1) // 16khz mono
let waveOut = new WaveOut()
waveOut.Init(sineWaveProvider)

waveOut.Play()

waveOut.Stop()
// sineWaveProvider.Frequency 
//sineWaveProvider.Frequency <- 1000




//type SineWaveProvider'() =
//    inherit NAudio.Wave.WaveProvider32()
//
//    let frequency = 1000.0
//    let amplitude = 0.25
//
//    let sin32 a = (float32) (System.Math.Sin a)
//
//    member this.Frequency = frequency
//    member this.Amplitude = amplitude
//    override this.Read(buffer:float32 [], offset:int, sampleCount:int) =
//        let sampleRate = base.WaveFormat.SampleRate
//
//        // Fold across simple sequence, so there's no mutation of sample
//        seq { for i in 0 .. sampleCount -> i }
//        |> Seq.fold (fun (sample, item) -> 
//                let sample' = sample + 1.0
//
//                // match
//                if sample' >= (float) sampleRate
//                then sample <- 0.0)
//
//                sin32 (2.0 * Math.PI * sample * this.Frequency)
//
//
//        seq { for i in 0 .. sampleCount -> 
//                iterateAndCapSample sampleRate
//                sin32 (2.0 * Math.PI * sample * this.Frequency)
//            }
//        |> Seq.iteri (fun i item -> buffer.[i+offset] <- (float32) item)
//
//        sampleCount
//
//
//
//
//
//
//
//
