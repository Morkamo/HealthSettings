using System;
using Exiled.API.Features;

namespace HealthSettings
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        
        public override string Author => "Morkamo";
        public override string Name => "HealthSettings";
        public override string Prefix => Name;
        
        public override Version Version => new Version(1, 0, 0);

        public Handler _Handler;
        
        public override void OnEnabled()
        {
            Instance = this;
            _Handler = new Handler();
            
            Exiled.Events.Handlers.Player.Spawning.Subscribe(_Handler.OnSpawning);
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Spawning.Unsubscribe(_Handler.OnSpawning);
            
            Instance = null;
            _Handler = null;

            base.OnDisabled();
        }
    }
}