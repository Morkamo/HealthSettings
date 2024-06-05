using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;
using PlayerRoles;

namespace HealthSettings
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Настройки HP ролей ( [RoleTypeId] : {hp_value} )\nОчистка списка или нулевое значение вернёт параметры по умолчанию")]
        public Dictionary<RoleTypeId, float> HpSettings { get; set; } = new Dictionary<RoleTypeId, float>()
        {
            [RoleTypeId.ClassD] = 150f,
            [RoleTypeId.Scientist] = 200f,
        };
        
        [Description("Настройки AHP щита у ролей ( [RoleTypeId] : {ahp_value} )\nОчистка списка или нулевое значение вернёт параметры по умолчанию")]
        public Dictionary<RoleTypeId, float> AhpSettings{ get; set; } = new Dictionary<RoleTypeId, float>()
        {
            [RoleTypeId.ClassD] = 25f,
            [RoleTypeId.Scientist] = 25f,
        };
        
        [Description("Настройки HS щита у SCP ролей ( [RoleTypeId] : {hs_value} )" +
                     "\nОчистка списка или нулевое значение вернёт параметры по умолчанию " +
                     "\nЗначение меньше стандартного автоматически вызовет процесс восстановления" +
                     "\nЗначение выше максимального стандартного порога не будет вызывать автоматическое восстановление до его достижения")]
        public Dictionary<RoleTypeId, float> HsSettings{ get; set; } = new Dictionary<RoleTypeId, float>()
        {
            [RoleTypeId.Scp173] = 1500f,
            [RoleTypeId.Scp049] = 500f,
        };
    }
}