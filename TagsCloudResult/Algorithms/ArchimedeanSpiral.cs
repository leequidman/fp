﻿using System;
using System.Drawing;
using TagsCloudResult.Settings;

namespace TagsCloudResult.Algorithms
{
    public class ArchimedeanSpiral : ISpiral
    {
        private readonly ICloudSettings cloudSettings;
        private double spiralAngle;

        public ArchimedeanSpiral(ICloudSettings cloudSettings)
        {
            this.cloudSettings = cloudSettings;
        }

        public Result<Point> GetNextPoint()
        {
            return Result.Of(() =>
                {
                    var x = cloudSettings.CenterPoint.X + (int) (spiralAngle * Math.Cos(spiralAngle));
                    var y = cloudSettings.CenterPoint.Y + (int) (spiralAngle * Math.Sin(spiralAngle));
                    spiralAngle++;

                    return new Point(x, y);
                })
                .RefineError("Не удалось получить следующую точку для размещения прямоугольника");
        }

        public double GetCurrentSpiralAngle() => spiralAngle;
    }
}
