using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;
using VL.Lib.IO;
using VL.UI.Core;

namespace DemoLib
{
    public partial class MyWindow : Form, IDisposable
    {
        public Subject<Rectangle> BoundsChanged { get; }

        public void SetSize(Rectangle bounds)
        {
            var boundsinPix = DIPHelpers.DIPToPixel(bounds);
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
            BoundsChanged.OnNext(DIPHelpers.DIP(Bounds));
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            BoundsChanged.OnNext(DIPHelpers.DIP(Bounds));
        }
    }
}
