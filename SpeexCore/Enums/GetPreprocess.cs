using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeexCore.Enums
{
    public enum GetPreprocess
    {
        Denoise = 1,
        Agc = 3,
        Vad = 5,
        AgcLevel = 7,
        Dereverb = 9,
        DereverbLevel = 11,
        DereverbDecay = 13,
        ProbStart = 15,
        ProbContinue = 17,
        NoiseSuppress = 19,
        EchoSuppress = 21,
        EchoSuppressActive = 23,
        EchoState = 25,
        AgcIncrement = 27,
        AgcDecrement = 29,
        AgcMaxGain = 31,
        AgcLoudness = 33,
        AgcGain = 35,
        PsdSize = 37,
        Psd = 39,
        NoisePsdSize = 41,
        NoisePsd = 43,
        Prob = 45,
        AgcTarget = 47
    }
}
