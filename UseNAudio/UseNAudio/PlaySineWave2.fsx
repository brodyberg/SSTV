
// float Frequency
// float Amplitude

// empty ctor
// derives WaveProvider32

// overrides Read(float array * int * int) -> int

#I @"..\packages\NAudio.1.7.3\lib\net35\"
#r "NAudio.dll"

open NAudio
open NAudio.Wave

type SineWaveProvider() =
    inherit NAudio.Wave.WaveProvider32()

    let frequency = 1000.0
    let amplitude = 0.25f

    member this.Frequency = frequency
    member this.Amplitude = amplitude

    override this.Read() = -1









