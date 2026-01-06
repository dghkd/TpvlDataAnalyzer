namespace TpvlDataAnalyzer.Model{ 

    public class Stats
    {
        public int rosterId { get; set; }
        public int squadId { get; set; }
        public int matchCount { get; set; }
        public int roundCount { get; set; }
        public int score { get; set; }
        public int fouls { get; set; }
        public int spikes { get; set; }
        public int attemptSpikes { get; set; }
        public int errorSpikes { get; set; }
        public int completedSpikes { get; set; }
        public SpikesMetrics spikesMetrics { get; set; }
        public int serves { get; set; }
        public int attemptServes { get; set; }
        public int errorServes { get; set; }
        public int completedServes { get; set; }
        public ServesMetrics servesMetrics { get; set; }
        public int blocks { get; set; }
        public int attemptBlocks { get; set; }
        public int errorBlocks { get; set; }
        public int completedBlocks { get; set; }
        public BlocksMetrics blocksMetrics { get; set; }
        public int defenses { get; set; }
        public int attemptDefenses { get; set; }
        public int errorDefenses { get; set; }
        public int completedDefenses { get; set; }
        public DefensesMetrics defensesMetrics { get; set; }
        public int passes { get; set; }
        public int attemptPasses { get; set; }
        public int errorPasses { get; set; }
        public int completedPasses { get; set; }
        public PassesMetrics passesMetrics { get; set; }
        public int sets { get; set; }
        public int attemptSets { get; set; }
        public int errorSets { get; set; }
        public int completedSets { get; set; }
        public SetsMetrics setsMetrics { get; set; }
        public double averagePointsPerGame { get; set; }
        public double averagePointsPerSet { get; set; }
        public int totalSpikeAndBlockScores { get; set; }
        public double spikeAndBlockSuccessRate { get; set; }
        public int totalPassAndDefenseSuccess { get; set; }
        public double passAndDefenseSuccessRate { get; set; }
    }

}