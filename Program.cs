using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace x264_dirs
{
    class Program
    {
        static void Main(string[] args)
        {
            // The goal: 
            // Run program and get folders named 0baseline-0Ultrafast, 3high10-4fast-yuv420 and 3high10-4fast-yuv420p10le
            // so it's visible what profile, preset and format is inside the folder


            string[] profileArr = { "baseline", "main", "high", "high10", "high422", "high444" };
            string[] presetArr = { "ultrafast", "superfast", "veryfast", "faster", "fast", "medium", "slow", "slower", "veryslow", "placebo" };
            string[] pix_fmtArr = { "yuv420p", "yuv422p", "yuv444p", "yuv420p10le", "yuv422p10le", "yuv444p10le" };


            string name = "";
            List<string> output = new List<string>();

            for (int profileInt = 0; profileInt < profileArr.Length; profileInt++)
            {
                for (int presetInt = 0; presetInt < presetArr.Length; presetInt++)
                {
                    for (int pix_fmtInt = 0; pix_fmtInt < pix_fmtArr.Length;pix_fmtInt++)
                    {
                        // don't create folders for stuff that doesn't work
                        if(profileInt == 0||profileInt==1||profileInt==2)
                        {
                            if (pix_fmtInt!=0)
                            {
                                break;
                            }
                            
                        }
                        if(profileInt==3)
                        {
                            if(pix_fmtInt!=0||pix_fmtInt!=3)
                            {
                                break;
                            }
                        }
                        
                        // switching gears, as High422 supports more formats than it does not, so it's easier to break when we meet a format that high422 does not support
                        if (profileInt == 4)
                        {
                            if (pix_fmtInt == 2 || pix_fmtInt == 5)
                            {
                                break;
                            }
                        }
                        // profileInt==5 supports everything. High444 supports everything

                        name = profileInt+profileArr[profileInt] + "-" + presetInt+presetArr[presetInt] + "-"+pix_fmtInt+pix_fmtArr[pix_fmtInt];
                        output.Add(name);
                    }
                    

                }

            }
            foreach (var na in output)
            {
                Directory.CreateDirectory(na);
                
            }
            
        }
    }
}
