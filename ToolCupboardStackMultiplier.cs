using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using UnityEngine;
using Pool = Facepunch.Pool;

namespace Oxide.Plugins
{
    [Info("Tool Cupboard Stack Multiplier", "jlee2834", "1.0.0")]
    [Description("Allows changing stack sizes in the tool cupboard.")]

    public class ToolCupboardStackMultiplier : RustPlugin
    {
        #region Variables

        private const string PermissionUseShift = "toolcupboardstackmultiplier.useshift";

        private static readonly object _true = true;

        private readonly Hash<ulong, float> _cacheMultipliers = new();
        private uint _toolCupboardPrefabID;

        #endregion Variables

        #region Initialization

        private void Init()
        {
            RegisterPermissions();
            CachePrefabIDs();
            CacheMultipliers();
        }

        private void OnServerInitialized() => CacheMultipliers();

        #endregion Initialization

        #region Configuration

        private PluginConfig _pluginConfig;

        public class PluginConfig
        {
            [JsonProperty(PropertyName = "Default Multiplier")]
            [DefaultValue(1f)]
            public float DefaultMultiplier { get; set; }

            [JsonProperty(PropertyName = "Tool Cupboard Multiplier")]
            [DefaultValue(1f)]
            public float ToolCupboardMultiplier { get; set; }
        }

        protected override void LoadDefaultConfig() => PrintWarning("Loading Default Config");

        protected override void LoadConfig()
        {
            base.LoadConfig();
            Config.Settings.DefaultValueHandling = DefaultValueHandling.Populate;
            _pluginConfig = Config.ReadObject<PluginConfig>() ?? new PluginConfig();
            if (_pluginConfig.DefaultMultiplier <= 0) _pluginConfig.DefaultMultiplier = 1f;
            if (_pluginConfig.ToolCupboardMultiplier <= 0) _pluginConfig.ToolCupboardMultiplier = 1f;
            Config.WriteObject(_pluginConfig);
        }

        #endregion Configuration

        #region Oxide Hooks

        private object OnMaxStackable(Item item)
        {
            if (item.info.stackable == 1 || item.info.itemType == ItemContainer.ContentsType.Liquid) return null;

            BaseEntity entity = item.GetEntityOwner() ?? item.GetOwnerPlayer();
            if (entity != null && entity.prefabID == _toolCupboardPrefabID)
            {
                float multiplier = _pluginConfig.ToolCupboardMultiplier;
                return Mathf.FloorToInt(multiplier * item.info.stackable);
            }

            return null;
        }

        #endregion Oxide Hooks

        #region Core Methods

        public void CachePrefabIDs()
        {
            _toolCupboardPrefabID = StringPool.Get("assets/prefabs/deployable/tool cupboard/cupboard.tool.deployed.prefab");
        }

        public void CacheMultipliers()
        {
            if (_pluginConfig.ToolCupboardMultiplier <= 0)
            {
                _pluginConfig.ToolCupboardMultiplier = _pluginConfig.DefaultMultiplier;
                Config.WriteObject(_pluginConfig);
            }
        }

        public void RegisterPermissions() => permission.RegisterPermission(PermissionUseShift, this);

        #endregion Core Methods
    }
}
