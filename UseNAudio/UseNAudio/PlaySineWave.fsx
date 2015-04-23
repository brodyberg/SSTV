// http://mark-dot-net.blogspot.com/2009/10/playback-of-sine-wave-in-naudio.html

#I @"..\packages\NAudio.1.7.3\lib\net35\"
#r "NAudio.dll"

open NAudio

[<AbstractClass>]
type WaveProvider32 () =
    abstract member SetWaveFormat: int -> int -> unit
    abstract member Read: byte array -> int -> int -> int
    abstract member Read: float array -> int -> int -> int
//    abstract member Read: float array * int * int -> int
//    abstract member Bar: (int * int * int) -> int

type SineWaveProvider32() =
    inherit WaveProvider32()

    override this.SetWaveFormat sampleRate channels = ()
    override this.Read floats these that = 0
    override this.Read bytes these that = -1
//    override this.Read' top left bottom = -1
//    override this.Read bytes these that = 0
//    override this.Bar(bar:int*int*int) = 1

let x = SineWaveProvider32()

x.SetWaveFormat 0 0
x.Read()

x.Read([||], 0, 0)

x.Read()
2 + 2

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

