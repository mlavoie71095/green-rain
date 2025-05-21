using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.GameData;

namespace GreenRainReplacer
{
    public class ModConfig
    {
        public bool ReplaceRainWithGreenRain { get; set; } = true;
    }

    public class ModEntry : Mod
    {
        private ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            Config = helper.ReadConfig<ModConfig>();
            helper.Events.GameLoop.DayStarted += OnDayStarted;
        }

        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            if (!Context.IsMainPlayer || !Config.ReplaceRainWithGreenRain)
                return;

            // Change tomorrow's weather if it's rain
            if (Game1.weatherForTomorrow == Game1.weather_rain)
            {
                Monitor.Log("Normal rain detected — replacing with green rain!", LogLevel.Info);
                Game1.weatherForTomorrow = Game1.weather_debris; // green rain in Fern Islands
            }
        }
    }
}