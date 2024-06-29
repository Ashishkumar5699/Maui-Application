
#if ANDROID
using Android.Content;
using Android.OS;
using Java.IO;
using Environment = Android.OS.Environment;
using Application = Android.App.Application;

#elif IOS
using Foundation;
using QuickLook;
using UIKit;
#elif WINDOWS
#endif

namespace Sonaar.Mobile.Services.SaveService
{
    public class SaveService
    {
        public void SaveAndView(string filename, string contentType, MemoryStream stream)
        {
        #if ANDROID

        string exception = string.Empty;
        string? root = null;

        if (Environment.IsExternalStorageEmulated)
        {
            root = Application.Context!.GetExternalFilesDir(Environment.DirectoryDownloads)!.AbsolutePath;
        }
        else
            root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

        Java.IO.File myDir = new(root + "/Syncfusion");
        myDir.Mkdir();

        Java.IO.File file = new(myDir, filename);

        if (file.Exists())
        {
            file.Delete();
        }

        try
        {
            FileOutputStream outs = new(file);
            outs.Write(stream.ToArray());

            outs.Flush();
            outs.Close();
        }
        catch (Exception e)
        {
            exception = e.ToString();
        }
        if (file.Exists())
        {
            try
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
                {
                    var fileUri = AndroidX.Core.Content.FileProvider.GetUriForFile(Application.Context, Application.Context.PackageName + ".provider", file);
                    var intent = new Intent(Intent.ActionView);
                    intent.SetData(fileUri);
                    intent.AddFlags(ActivityFlags.NewTask);
                    intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                    Application.Context.StartActivity(intent);
                }
                else
                {
                    var fileUri = file.AbsolutePath;
                    var intent = new Intent(Intent.ActionView);
                    intent.SetDataAndType((global::Android.Net.Uri?)fileUri, contentType);
                    intent = Intent.CreateChooser(intent, "Open File");
                    intent!.AddFlags(ActivityFlags.NewTask);
                    Application.Context.StartActivity(intent);
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }

        }

        #elif IOS

        string exception = string.Empty;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        string filePath = Path.Combine(path, filename);
        try
        {
            FileStream fileStream = File.Open(filePath, FileMode.Create);
            stream.Position = 0;
            stream.CopyTo(fileStream);
            fileStream.Flush();
            fileStream.Close();
        }
        catch (Exception e)
        {
            exception = e.ToString();
        }
        if (contentType != "application/html" || exception == string.Empty)
        {
        #pragma warning disable CA1416 //This call site is reachable on: 'iOS' 14.2 and later, 'maccatalyst' 14.2 and later. 'UIApplication.KeyWindow.get' is unsupported on: 'ios' 13.0 and later, 'maccatalyst' 13.0 and later.
                        UIViewController currentController = UIApplication.SharedApplication!.KeyWindow!.RootViewController;
        #pragma warning restore CA1416 //This call site is reachable on: 'iOS' 14.2 and later, 'maccatalyst' 14.2 and later. 'UIApplication.KeyWindow.get' is unsupported on: 'ios' 13.0 and later, 'maccatalyst' 13.0 and later.
                        while (currentController!.PresentedViewController != null)
                            currentController = currentController.PresentedViewController;

                        QLPreviewController qlPreview = new();
                        QLPreviewItem item = new QLPreviewItemBundle(filename, filePath);
                        qlPreview.DataSource = new PreviewControllerDS(item);
                        currentController.PresentViewController((UIViewController)qlPreview, true, null);
                    }
        #elif WINDOWS
                          handler.NativeView.Background = Colors.Red.ToNative();
        #endif
        }

    }

    #if IOS
    public class QLPreviewItemFileSystem : QLPreviewItem
    {
        readonly string _fileName, _filePath;

        public QLPreviewItemFileSystem(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        public override string PreviewItemTitle
        {
            get
            {
                return _fileName;
            }
        }
        public override NSUrl PreviewItemUrl
        {
            get
            {
                return NSUrl.FromFilename(_filePath);
            }
        }
    }

    public class QLPreviewItemBundle : QLPreviewItem
    {
        readonly string _fileName, _filePath;
        public QLPreviewItemBundle(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        public override string PreviewItemTitle
        {
            get
            {
                return _fileName;
            }
        }
        public override NSUrl PreviewItemUrl
        {
            get
            {
                var documents = NSBundle.MainBundle.BundlePath;
                var lib = Path.Combine(documents, _filePath);
                var url = NSUrl.FromFilename(lib);
                return url;
            }
        }
    }

    public class PreviewControllerDS : QLPreviewControllerDataSource
    {
        private readonly QLPreviewItem _item;

        public PreviewControllerDS(QLPreviewItem item)
        {
            _item = item;
        }

        public override nint PreviewItemCount(QLPreviewController controller)
        {
            return (nint)1;
        }

        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        {
            return _item;
        }
    }
    #endif
}