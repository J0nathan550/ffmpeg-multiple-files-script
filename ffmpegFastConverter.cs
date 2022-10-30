using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

public class ffmpegFastConverter
{
    public static void Main(string[] args)
    {
        string path = "D:\\Music\\ffmpeg\\bin"; // path to ffmpeg + music inside
        bool delete = true; // if you want to clean ffmpeg folder from video and leave only audio files

        List<string> files = new List<string>();
        if (delete)
        {
            foreach (var file in Directory.EnumerateFiles(path))
            {
                if (file.EndsWith(".exe") || file.EndsWith(".mp3"))
                {
                    continue;
                }
                files.Add(file);    
            }
            foreach (var file in files)
            {
                File.Delete(file);
            }
            Console.WriteLine("Done!");
            return;
        }

        foreach (var file in Directory.EnumerateFiles(path))
        {
            if (file.EndsWith(".exe"))
            {
                continue;
            }
            files.Add("\"" + file +"\"");
        }
        foreach (var item in files)
        {
            string info = $"/k ffmpeg.exe -i {item} {item}.mp3"; // can be any format that you like, not especially audio, like avi or something but you get the thing.
            Process p = new Process();
            p.StartInfo.FileName = "C:\\Windows\\system32\\cmd.exe";
            p.StartInfo.WorkingDirectory = @"D:\Music\ffmpeg\bin";
            p.StartInfo.Arguments = info;
            p.Start();
        }
        Console.WriteLine("Done!");
        Console.ReadKey();
    }

}
