namespace Chloride.RA2.MapExt.Components
{
    public struct ScriptAction
    {
        public int Id = -1;
        public int Param = -1;

        public ScriptAction() {}

        /// <summary>Get ur building index into different modes:
        /// <para/>0 - MIN threat
        /// <para/>1 - MAX threat
        /// <para/>2 - NEARest
        /// <para/>3 - FURTHest
        /// </summary>
        public void ConvertBuildingIndex(int indexOfBuilding, int k) => 
            Param = indexOfBuilding << (k switch {
                1 => 16,
                2 => 17,
                3 => 18,
                _ => 0
            });
    }
}