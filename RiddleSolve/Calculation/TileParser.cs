using System;
using RiddleSolve.Model;
using static RiddleSolve.Model.FacePart;
using Color = System.Drawing.Color;

namespace RiddleSolve.Calculation
{
    public static class TileParser
    {
        private const int TileSize = 297;
        private const int SmileDistance = 77;
        private const int ColorDistance = 100;
        private static readonly Position HalfTile = new Position(TileSize / 2, TileSize / 2);
        
        public static Tile[,] ParseTiles(Color[] pixels, int width, int height)
        {
            int columns = (width - 1) / TileSize;
            int rows = (height - 1) / TileSize;
            var result = new Tile[rows, columns];

            for (var row = 0; row < rows; row++)
            for (var column = 0; column < columns; column++)
            {
                Position position = (row, column);
                Position tileMiddle = position * TileSize + HalfTile;
                result[row, column] = new Tile
                (
                    GetFacePart(pixels, width, tileMiddle, Side.Left),
                    GetFacePart(pixels, width, tileMiddle, Side.Top),
                    GetFacePart(pixels, width, tileMiddle, Side.Right),
                    GetFacePart(pixels, width, tileMiddle, Side.Bottom)
                );
            }

            return result;
        }

        private static FacePart GetFacePart(Color[] pixels, int rowPixels, Position middle, Side side)
        {
            var relativePosition = side.ToRelativePosition();
            
            var smilePosition = middle + relativePosition * SmileDistance;
            var partType = ParsePartType(pixels[smilePosition.GetIndex(rowPixels)]);

            var colorPosition = middle + relativePosition * ColorDistance;
            var color = ParseColor(pixels[colorPosition.GetIndex(rowPixels)]);
            
            return new FacePart(partType, color);
        }

        private static PartType ParsePartType(Color color)
        {
            if (color.R > 128 || color.G > 128 || color.B > 128) return PartType.Eyes;
            return PartType.Mouth;
        }
        
        private static FaceColor ParseColor(Color color)
        {
            if (color.R > 200 && color.G > 200) return FaceColor.Yellow;
            if (color.R > 200) return FaceColor.Red;
            if (color.G > 200) return FaceColor.Green;
            if (color.B > 200) return FaceColor.Blue;
            throw new ArgumentException("Invalid parsed color");
        }
    }
}