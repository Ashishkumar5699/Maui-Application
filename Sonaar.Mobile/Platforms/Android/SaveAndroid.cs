﻿using Android.Content;
using Android.OS;
using Java.IO;
using Environment = Android.OS.Environment;
using Application = Android.App.Application;

namespace Sonaar.Mobile.Services.SaveService
{
    public partial class SaveService
    {
        //public partial void SaveAndView(string filename, string contentType, MemoryStream stream)
        //{
        //    string exception = string.Empty;
        //    string root = null;

        //    if (Environment.IsExternalStorageEmulated)
        //    {
        //        root = Application.Context!.GetExternalFilesDir(Environment.DirectoryDownloads)!.AbsolutePath;
        //    }
        //    else
        //        root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

        //    Java.IO.File myDir = new(root + "/Syncfusion");
        //    myDir.Mkdir();

        //    Java.IO.File file = new(myDir, filename);

        //    if (file.Exists())
        //    {
        //        file.Delete();
        //    }

        //    try
        //    {
        //        FileOutputStream outs = new(file);
        //        outs.Write(stream.ToArray());

        //        outs.Flush();
        //        outs.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        exception = e.ToString();
        //    }
        //    if (file.Exists())
        //    {
        //        try
        //        {
        //            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.N)
        //            {
        //                var fileUri = AndroidX.Core.Content.FileProvider.GetUriForFile(Android.App.Application.Context, Android.App.Application.Context.PackageName + ".provider", file);
        //                var intent = new Intent(Intent.ActionView);
        //                intent.SetData(fileUri);
        //                intent.AddFlags(ActivityFlags.NewTask);
        //                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
        //                Android.App.Application.Context.StartActivity(intent);
        //            }
        //            else
        //            {
        //                var fileUri = Android.Net.Uri.Parse(file.AbsolutePath);
        //                var intent = new Intent(Intent.ActionView);
        //                intent.SetDataAndType(fileUri, contentType);
        //                intent = Intent.CreateChooser(intent, "Open File");
        //                intent!.AddFlags(ActivityFlags.NewTask);
        //                Android.App.Application.Context.StartActivity(intent);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            var err = ex.Message;
        //            throw;
        //        }

        //    }
        //}
    }
}
