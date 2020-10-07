﻿namespace RiddleSolve.Model
{
    public interface ITile
    {
        /// <summary>
        /// Possible tile rotation
        /// </summary>
        public enum TileRotation { Up, Right, Down, Left }
        
        /// <summary>
        /// Current tile rotation
        /// </summary>
        public TileRotation Rotation { get; }
        
        /// <summary>
        /// Position of tile in unsolved board
        /// </summary>
        Position TileFromPosition { get; }
        
        /// <summary>
        /// Face on left side of tile
        /// </summary>
        FacePart Left { get; }
        
        /// <summary>
        /// Face on top side of tile
        /// </summary>
        FacePart Top { get; }
        
        /// <summary>
        /// Face on right side of tile
        /// </summary>
        FacePart Right { get; }
        
        /// <summary>
        /// Face on bottom side of tile
        /// </summary>
        FacePart Bottom { get; }

        /// <summary>
        /// Gets FacePart on specified side of board
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        FacePart GetFacePart(Side side);
        
        /// <summary>
        /// Gets tile when applied rotation
        /// </summary>
        /// <param name="rotation"></param>
        /// <returns></returns>
        RotatedTile GetRotated(TileRotation rotation);
    }
}