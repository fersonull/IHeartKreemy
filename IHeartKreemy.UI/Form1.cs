using System;
using System.IO;
using System.Windows.Forms;
using IHeartKreemy.Core.Services;


namespace IHeartKreemy.UI
{
    public partial class IHeartKreemy : Form
    {
        public KeyboardHookService _listener;
        public AudioService _audio;


        public IHeartKreemy()
        {
            InitializeComponent();


            //// 1. Calculate the exact full path to the file
            //string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "click_short.wav");

            // 2. Pass this full path to your service
            _audio = new AudioService("Assets/click_short.wav");

            _listener = new KeyboardHookService();
            _listener.KeyPressed += (s, args) => _audio.PlayCreamySound();
            _listener.Start();
        }

        protected override void SetVisibleCore(bool value)
        {
            // This prevents the window from EVER showing up
            // We only want it visible if we explicitly say so (which we won't)
            base.SetVisibleCore(false);
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clean up the hook so it doesn't get stuck in memory
            _listener.Dispose();

            // Actually close the app
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void StartBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
