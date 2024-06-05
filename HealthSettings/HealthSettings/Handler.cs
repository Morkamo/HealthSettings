using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace HealthSettings
{
    public class Handler
    {
        public void OnSpawning(SpawningEventArgs ev)
        {
            if (Plugin.Instance.Config.HpSettings.TryGetValue(ev.Player.Role.Type, out var hp))
            {
                if (Plugin.Instance.Config.HpSettings.ContainsValue(0))
                    return;
                
                ev.Player.Health = hp;
            }
            
            if (Plugin.Instance.Config.HsSettings.TryGetValue(ev.Player.Role.Type, out var hs))
            {
                if (Plugin.Instance.Config.HpSettings.ContainsValue(0) || ev.Player.LeadingTeam is not LeadingTeam.Anomalies)
                    return;
                
                ev.Player.HumeShield = hs;
            }
            
            Timing.CallDelayed(1f, () =>
            {
                if (Plugin.Instance.Config.AhpSettings.TryGetValue(ev.Player.Role.Type, out var ahp))
                {
                    if (Plugin.Instance.Config.HpSettings.ContainsValue(0))
                        return;
                
                    ev.Player.AddAhp(ahp, ahp, 0);
                }
            });
        }
    }
}