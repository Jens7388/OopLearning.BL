using System;
using System.Collections.Generic;
using System.Text;

namespace OopLearning.BL
{
    public class Field
    {
        private double width;
        private double length;
        private double area;
        private string crop;
        private double yield;

        public Field(double width, double length, double area, string crop, double yield)
        {
            Width = width;
            Length = length;
            Area = area;
            Crop = crop;
            Yield = yield;
        }

        public double Width
        {
            get { return width; }
            set
            {
                if(value <= 0.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(width), "Width skal være over 0.0!");
                }
                if(value != width)
                {
                    width = value;
                }
            }
        }
        public double Length
        {
            get { return length; }
            set
            {
                if(value <= 0.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(length), "Length skal være over 0.0!");
                }
                if(value != length)
                {
                    length = value;
                }
            }
        }
        public double Area {get;}
        public string Crop
        {
            get { return crop; }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateCrop(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(crop), validationResult.errorMessage);
                }
                if(value != crop)
                {
                    crop = value;
                }
            }
        }
        public double Yield {get;}
        public static (bool, string) ValidateCrop(string crop)
        {
            if(crop is null)
            {
                return (false, "Crop er null!");
            }
            if(crop.ToLower() != "potatoes" && crop.ToLower() != "wheat" && crop.ToLower() != "oak" && crop.ToLower() != "carrots")
            {
                return (false, "Crop må kun være 'potatoes', 'wheat', 'oak' eller 'carrots'!");
            }
            else
            {
                return (true, String.Empty);
            }
        }
    }
}