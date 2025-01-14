# TC-Stack-Multiplier
Tool Cupboard Stack Multiplier is a plugin for Oxide that allows rust server administrators & owners to modify stack sizes in tool cupboards for the game Rust. It provides flexibility in configuring stack multipliers, making resource management in tool cupboards more customizable.

**Features**
1. Adjustable Stack Multipliers: Configure the stack size multiplier for items stored in tool cupboards.
2. Customizable Settings: Set default and tool cupboard-specific multipliers in the configuration file.
3. Permission System: Grant or restrict usage with Oxide permissions.
4. Efficient Resource Handling: Ensures smooth integration with the game's mechanics while applying multipliers.

**Installation**
1. Download the Plugin: Place the ToolCupboardStackMultiplier.cs file into the oxide/plugins/ directory of your Rust server.

2. Restart the Server: Restart your server to load the plugin.

3. Configure the Plugin: Modify the oxide/config/ToolCupboardStackMultiplier.json file to set your desired stack multipliers.


**Configuration**
The plugin supports the following configurable options:

Default Multiplier: Applied when no specific multiplier is set. (Default: 1)
Tool Cupboard Multiplier: Multiplier applied to stack sizes in tool cupboards. (Default: 1)
Example configuration:
```json
{
  "Default Multiplier": 1.0,
  "Tool Cupboard Multiplier": 2.0 // will multiply tc stack sizes to 2x
}
```

 ![image](https://github.com/user-attachments/assets/062095fd-1442-4d0d-accc-275c3ff2d6ff)
 ![image](https://github.com/user-attachments/assets/c3388180-2614-4d7b-906a-c2a8c43d2729)


**Permissions**
toolcupboardstackmultiplier.useshift: Grants the ability to use shift functionality with stack multipliers.

**License**
This plugin is provided as-is. Modify and distribute freely under the terms of the MIT License. 
