// http://mark-dot-net.blogspot.com/2009/10/playback-of-sine-wave-in-naudio.html

#I @"..\packages\NAudio.1.7.3\lib\net35\"
#r "NAudio.dll"

open NAudio

[<AbstractClass>]
type WaveProvider32 () =
    abstract member SetWaveFormat: int -> int -> unit
    abstract member Read: (byte array * int * int) -> int
    abstract member Read: (float array * int * int) -> int

type SineWaveProvider32() =
    inherit WaveProvider32()

    override this.SetWaveFormat sampleRate channels = ()
    override this.Read (x:(byte array * int * int)) = -3
    override this.Read (y:(float array * int * int)) = -4

let n = ([| 86uy |], 0, 0)

let y = SineWaveProvider32()
y.Read n