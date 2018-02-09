using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using PresentationApp.Utils;

namespace PresentationApp.Views
{
    [Activity(Label = "PlayVideoActivity", 
        Theme = "@style/Theme.MyTheme",
        ScreenOrientation = ScreenOrientation.Landscape)]
    public class ShowDocumentation : Activity, ISurfaceHolderCallback
    {
        private VideoView videoView;

        private MediaPlayer player;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var fileName = Intent.GetStringExtra(MainActivity.FileName);
            if (fileName.EndsWith(".pdf"))
            {
                OpenPdfFile(fileName);
            }
            else if (fileName.EndsWith(".mp4"))
            {
                OpenVideoFile(fileName);
            }
        }

        private void OpenPdfFile(string fileName)
        {
            SetContentView(Resource.Layout.ViewPdfLayout);

            var tvTitle = FindViewById<TextView>(Resource.Id.tvTitle);
            tvTitle.Text = fileName;

            var filePath = FileUltility.CopyFileToExternalStorage(fileName);
            var webView = FindViewById<WebView>(Resource.Id.webView);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.AllowFileAccess = true;
            webView.Settings.AllowUniversalAccessFromFileURLs = true;
            webView.Settings.BuiltInZoomControls = true;
            webView.LoadUrl("file:///android_asset/pdfjs/web/viewer.html?file=" + filePath + "#zoom=page-width");
        }

        private void OpenVideoFile(string fileName)
        {
            SetContentView(Resource.Layout.PlayVideoLayout);
            videoView = FindViewById<VideoView>(Resource.Id.videoView);
            Play(fileName);
        }

        private void Play(string fullPath)
        {
            var holder = videoView.Holder;
            holder.SetType(SurfaceType.PushBuffers);
            holder.AddCallback(this);
            player = new MediaPlayer();
            var afd = Assets.OpenFd(fullPath);
            if (afd == null) return;
            player.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
            player.Prepare();
            player.Start();
        }

        public void SurfaceChanged(ISurfaceHolder holder, Format format, int width, int height)
        {
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            player.SetDisplay(holder);
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            player.Stop();
        }
    }
}