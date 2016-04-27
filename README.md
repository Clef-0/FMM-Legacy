# FMM
Mod manager for Halo Online.

![Screenshot of FMM](https://vgy.me/uljH0n.png)

### Make your mods compatible
A .fm file should be treated as a .bat file being run from the root Halo Online folder. The only files it should modify are files in /maps (ones which have been backed up by FMM).

FMM hides the console when executing batch installers, to provide a cleaner experience for the user. If an output to the user is desperately needed, start another CMD window by using the following line:
START CMD /C "ECHO Example && PAUSE"

This opens a new command prompt window which will not be hidden like the installer window. The other CMD window won't be able to send input back to this installer and will not pause the installer. Any attempt to use PAUSE in the installer will freeze FMM, as the installer is hidden, so the user cannot press a key to continue.

All files (including your mod's supported version of HaloOnlineTagTool) should be stored in your /mods/tagmods/<modname> directory, reducing clutter for the user. FMM simply renames the .fm file to .bat and executes it as if it were run from the main directory (the one containing eldorado.exe).

If you'd rather use one download for both non-users and users of FMM, you can always just include an .fm file that starts your batch installer.
