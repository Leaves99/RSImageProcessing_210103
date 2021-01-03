using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using OpenCvSharp;
namespace RSImageProgressing
{
    class resFoudation
    {
        //一次多项式模型
        double a0, a1, a2;
        double b0, b1, b2;

        //计算变换系数，人工配准
        public void Coefficient(List<double[,]> CoreList, List<double[,]> StanList)
        {
            double[,] A = new double[4, 3];
            for (int i = 0; i < CoreList.Count; i++)
            {
                A[i, 0] = 1;
                A[i, 1] = CoreList[i][0, 0];
                A[i, 2] = CoreList[i][0, 1];

            }
            double[,] Lx = new double[4, 1];
            double[,] Ly = new double[4, 1];
            for (int i = 0; i < StanList.Count; i++)
            {
                Lx[i, 0] = StanList[i][0, 0];
                Ly[i, 0] = StanList[i][0, 1];
            }

            //调用库进行相关的计算
            var A_DenseMatrix = DenseMatrix.OfArray(A);
            var Lx_DenseMatrix = DenseMatrix.OfArray(Lx);
            var Ly_DenseMatrix = DenseMatrix.OfArray(Ly);

            var a = (A_DenseMatrix.Transpose() * A_DenseMatrix).Inverse()
                * (A_DenseMatrix.Transpose() * Lx_DenseMatrix);
            var b = (A_DenseMatrix.Transpose() * A_DenseMatrix).Inverse()
                * (A_DenseMatrix.Transpose() * Ly_DenseMatrix);
            a0 = a[0, 0];
            a1 = a[1, 0];
            a2 = a[2, 0];
            b0 = b[0, 0];
            b1 = b[1, 0];
            b2 = b[2, 0];
        }

        //影像配准以及输出
        public void ImageRegistration(Bitmap CorBitmap)
        {
            //获取角点坐标
            double[,] endpoint_xy = new double[4, 2];
            endpoint_xy[0, 0] = 0; endpoint_xy[0, 1] = 0;
            endpoint_xy[1, 0] = 0; endpoint_xy[1, 1] = CorBitmap.Height;
            endpoint_xy[2, 0] = CorBitmap.Width; endpoint_xy[2, 1] = 0;
            endpoint_xy[3, 0] = CorBitmap.Width; endpoint_xy[3, 1] = CorBitmap.Height;

            //计算输出范围
            double[,] endpoint_XY = new double[4, 2];
            for (int i = 0; i < 4; i++)
            {
                endpoint_XY[i, 0] = a0 + a1 * endpoint_xy[i, 0] + a2 * endpoint_xy[i, 1];
                endpoint_XY[i, 1] = b0 + b1 * endpoint_xy[i, 0] + b2 * endpoint_xy[i, 1];
            }

            //输出影像最小范围
            double Xmin = Math.Min(endpoint_XY[0, 0], Math.Min(endpoint_XY[1, 0], Math.Min(endpoint_XY[2, 0], endpoint_XY[3, 0])));
            double Xmax = Math.Max(endpoint_XY[0, 0], Math.Max(endpoint_XY[1, 0], Math.Max(endpoint_XY[2, 0], endpoint_XY[3, 0])));

            double Ymin = Math.Min(endpoint_XY[0, 1], Math.Min(endpoint_XY[1, 1], Math.Min(endpoint_XY[2, 1], endpoint_XY[3, 1])));
            double Ymax = Math.Max(endpoint_XY[0, 1], Math.Max(endpoint_XY[1, 1], Math.Max(endpoint_XY[2, 1], endpoint_XY[3, 1])));

            //设定输出分辨率为1米
            int OutputW = (int)((Xmax - Xmin) / 1) + 50;
            int OutputH = (int)((Ymax - Ymin) / 1) + 50;//防止溢出

            //构建位图
            double Xp, Yp;
            Bitmap OutputBitmap = new Bitmap(OutputW, OutputH, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Color curColor;
            for (int x = 0; x < CorBitmap.Width; x++)
            {
                for (int y = 0; y < CorBitmap.Height; y++)
                {
                    Xp = a0 + x * a1 + y * a2;
                    Yp = b0 + x * b1 + y * b2;

                    int x1 = (int)((Xp - Xmin) / 1);
                    int y1 = (int)((Yp - Ymin) / 1);

                    curColor = CorBitmap.GetPixel(x, y);
                    OutputBitmap.SetPixel(x1, y1, curColor);
                }
            }
            Mat result = OpenCvSharp.Extensions.BitmapConverter.ToMat(OutputBitmap);
            Cv2.ImShow("Result", result);
            Cv2.WaitKey(0);
            //Result bitmap = new Result();
            //bitmap.Showbitmap = OutputBitmap;
            //bitmap.ShowDialog();
        }
    }
}
