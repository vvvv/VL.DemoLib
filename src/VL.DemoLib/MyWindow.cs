using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;
using VL.Core.Properties;
using VL.Lib.IO;

namespace DemoLib
{
    public partial class MyWindow : Form, IDisposable
    {
        public Subject<Rectangle> BoundsChanged { get; }

        public void SetSize(Rectangle bounds)
        {
            var boundsinPix = Settings.DIPToPixel(bounds);
            if (boundsinPix != Bounds)
                Bounds = boundsinPix;
        }

        public MyWindow()
        {
            BoundsChanged = new Subject<Rectangle>();
            InitializeComponent();
            SetSize(new Rectangle(1200, 50, 600, 400));
            Show();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            BoundsChanged.OnNext(Settings.DIP(Bounds));
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            BoundsChanged.OnNext(Settings.DIP(Bounds));
        }
    }
}
