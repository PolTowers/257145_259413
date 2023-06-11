﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Keyless]
    public class Coordinate
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Coordinate()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Coordinate(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }

        public bool VerifyCoordinate(double x, double y, double z)
        {
            return VerifyCoordinateValues(x) && VerifyCoordinateValues(y) && VerifyCoordinateValues(z);
        }

        public bool VerifyCoordinateValues(Object coordinate)
        {
            return coordinate.GetType() == typeof(double);
        }

        public override string ToString()
        {
            return "x: " + this.x + " y: " + this.y + " z: " + this.z;
        }
    }
}
