namespace Magica.Objects.Units.Skills.DefenceSkills
{
    /// <summary>
    /// Class that represents all block skills in the game.
    /// </summary>
    internal class Block : DefenceSkill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="asset">An array that contains the appearance of the block skill.</param>
        /// <param name="name">A name of the block skill.</param>
        /// <param name="manaCost">An amount of the manacost of the block skill.</param>
        public Block(string[] asset, string name, int manaCost)
            : base(asset, name, manaCost)
        {
        }
    }
}
