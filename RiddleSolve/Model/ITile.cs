namespace RiddleSolve.Model
{
    public interface ITile
    {
        /// <summary>
        /// Possible tile sides
        /// </summary>
        public enum TileSide { Left, Top, Right, Bottom }
        
        /// <summary>
        /// Possible tile rotations
        /// </summary>
        public enum TileRotation { None, Right, Down, Left }
        
        /// <summary>
        /// Current tile rotation
        /// </summary>
        public TileRotation Rotation { get; }
        
        /// <summary>
        /// Position of tile in unsolved board
        /// </summary>
        Position FromPosition { get; }
        
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
        FacePart GetFacePart(TileSide side);
        
        /// <summary>
        /// Gets tile when applied rotation
        /// </summary>
        /// <param name="addedRotation"></param>
        /// <returns></returns>
        RotatedTile GetRotated(TileRotation addedRotation);
    }
}