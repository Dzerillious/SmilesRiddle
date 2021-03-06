﻿using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using RiddleSolve.Model;
using static RiddleSolve.Model.ITile;

namespace RiddleSolve.ViewModel
{
    public class RotatedImageViewModel : ViewModelBase
    {
        public BitmapSource BitmapSource { get; }
        
        public double UnsolvedX { get; }
        public double UnsolvedY { get; }
        public double SolvedX { get; }
        public double SolvedY { get; }
        public double Angle { get; }
        
        private bool _isSolvedDisplayed;
        public bool IsSolvedDisplayed
        {
            get => _isSolvedDisplayed;
            set => Set(ref _isSolvedDisplayed, value);
        }

        public RotatedImageViewModel(BitmapSource bitmapSource, ITile tile,
            double unsolvedX, double unsolvedY, double solvedX, double solvedY)
        {
            BitmapSource = bitmapSource;
            
            UnsolvedX = unsolvedX;
            UnsolvedY = unsolvedY;
            SolvedX = solvedX;
            SolvedY = solvedY;
            Angle = GetAngle(tile);
        }

        private static double GetAngle(ITile rotatedTile)
            => rotatedTile.Rotation switch
            {
                TileRotation.Left  => -90,
                TileRotation.None  => 0,
                TileRotation.Right => 90,
                TileRotation.Down  => 180,
                _                  => 0,
            };
    }
}