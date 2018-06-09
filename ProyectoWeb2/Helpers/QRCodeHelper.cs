﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace ProyectoWeb2.Helpers
{
    public class QRCodeHelper
    {

        public System.Drawing.Image GenerateQRCode(string content, int size)
        {
            QrEncoder encoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode;
            encoder.TryEncode(content, out qrCode);

            GraphicsRenderer gRenderer = new GraphicsRenderer(new FixedModuleSize(4, QuietZoneModules.Two), System.Drawing.Brushes.Black, System.Drawing.Brushes.White);
            //Graphics g = gRenderer.Draw(qrCode.Matrix);

            MemoryStream ms = new MemoryStream();
            gRenderer.WriteToStream(qrCode.Matrix, ImageFormat.Bmp, ms);

            var imageTemp = new Bitmap(ms);

            var image = new Bitmap(imageTemp, new System.Drawing.Size(new System.Drawing.Point(size, size)));

            //image.Save("file.bmp", ImageFormat.Bmp);

            return (System.Drawing.Image)image;
        }
    }
}