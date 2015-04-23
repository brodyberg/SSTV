// http://mark-dot-net.blogspot.com/2009/10/playback-of-sine-wave-in-naudio.html

//#I "..\..\packages\NAudio.1.7.3\lib\net35\"

open NAudio

[<AbstractClass>]
type WaveProvider32 () =
    abstract member SetWaveFormat: int -> int -> unit
    abstract member Read: (byte array * int * int) -> int
    abstract member Read: (float array * int * int) -> int

type SineWaveProvider32() =
    inherit WaveProvider32()

    override this.SetWaveFormat sampleRate channels = ()
    override this.Read(foo: float array * int * int) = 0
    override this.Read(foo: byte array * int * int) = 0

let x = SineWaveProvider32()


2 + 2

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
