# FMM (Foundation Mod Manager)
Mod manager for Halo Online.

![FMM Logo](https://vgy.me/EvUokK.png)
![Screenshot of FMM](https://vgy.me/2GswO9.png)

### To-do
* HaloCafe integration for easy mod downloads
* Installer output system so the user knows a mod is still installing and that FMM hasn't just frozen

## Tutorials
### Make your mods compatible
A .fm file should be treated as a .bat file being run from the root Halo Online folder (as in your first command might be to "cd mods/tagmods/mod" or "cd maps" to work with the user's map files. The only files it should modify are files in /maps (ones which have been backed up by FMM).

FMM hides the console when executing batch installers, to provide a cleaner experience for the user. If an output to the user is needed, use the command "ECHO FMM\_OUTPUT <text>" in your .fm. If you need to alert the user, use "ECHO FMM\_ALERT <text>" to open a message box.

All files (including your mod's supported version of HaloOnlineTagTool) should be stored in your /mods/tagmods/<modname> directory, reducing clutter for the user. FMM simply renames the .fm file to .bat and executes it as if it were run from the main directory (the one containing eldorado.exe).
