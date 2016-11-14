# DS ROM Patcher
Normaly, distributing ROM hacks for NDS ROMs involves an XDelta patch applied to the entire ROM.  3DS hacks usually involves tedious ROM extraction and file replacement.  Patches applied to the ROM as a whole do not support multiple regions of games, and tedious ROM extraction and file replacement is a chore.  DS ROM Patcher aims to fix that.

## Concepts and terminology
### Patch
A patch is the data needed to alter a file without distributing the altered version in its entirety.  Certain kinds of patches might be merge-safe, meaning that multiple patches from multiple mods can be applied to the same file.

### Mod
A mod is a group of file patches that intend to change something about a game.  Examples of mods:
- Removing the border lines in Pokémon games
- Changing the moves TMs teach in Pokémon games
- Altering Pokémon spawns
- Altering Pokémon level progression and other balance concerns

### Modpack
A modpack is a collection of mods for a particular game, in addition to the tools required to apply them.

## Usage
### Applying a Modpack (GUI)
Applying a modpack is designed to be as user-friendly as possible.  Following these steps will result in a modified ROM being created.
 1. Extract the distribution zip file.
 2. Open DSPatcher.exe.
 3. For "Input", choose a ROM compatible with the modpack.
 4. Compatible mods will be listed and can be checked or unchecked as desired.
 5. Click "Patch" and respond to any prompts.

### Applying a Modpack (Automatic)
Modpacks are designed to be applied using automated tools.  Using DSPatcher.exe as a code library for applying modpacks is semi-supported, but the general process for calling it is as follows:
 1. Extract the distribution zip file.
 2. Execute the process `DSPatcher.exe <Source ROM> <Output ROM> [-hans]`
 3. Wait for the process to complete, and <Output ROM> will be the altered version of <Source ROM>

### Creating a Modpack
Modpack creation is still under construction, but can be done, albeit more manual steps than ideal.  Following these steps will result in a zip file that contains everything needed to apply your ROM hack, with the exception of the .Net Framework 4.6.
 1. Extract the zip file from the latest Github release.
 2. (Optional) Use the Patchers -> Import Patcher Pack to import any patching tools specific to the game you're modding.
	* XDelta will be used for any file formats without patchers, and these patches will not be merge safe.  Take care to ensure the mods in your mod pack do not conflict with each other.
	* Instructions for creating such a patcher pack will be released at a later date.  Developers who wish to create a patcher pack before this time may contact the author or open an issue on GitHub.
 3. Use the Modpack -> Edit Metadata menu option to edit the metadata for your modpack.  Click `Save` when finished.
	* Name is the user-friendly name of your mod.
	* Short name is needed for 3DS games to generate filenames for HANS.  The exact requirements are unknown, but try to avoid special characters, and make sure it's not too long.
	* Author is whomever is responsible for the modpack.  If you're collecting several mods made by others for a unique game experience, this is you.  If you're making a modpack just to simplify installing someone else's hack, please enter the name of the mod author.
	* Version is a string differentiating _this_ build of the modpack from any others you may have made.  There's no rules for this, just try to ensure it makes logical sense.
	* System is exactly what it says on the tin: the system on which the game you're modding runs.  Supported values are `3DS` and `NDS`.
	* Game code is a regular expression that matches the game code of any supported game.  For 3DS games, this is the 16 digit title ID.  For NDS games, this is the 4 letter game code.
 4. Use Modpack -> Create Mod.  Follow the below steps and repeat for every mod you wish to create.
 
  	 A. Browse to the original ROM.
  	 B. Browse to the modified ROM.
  	 C. Fill in metadata.
		* ID is any arbitrary string that can differentiate this mod from any others for a particular game.  Try to make it user-friendly, since other modpack creators may use it.
		* Friendly name is the name of the mod users will see when applying the modpack.
		* Author is whomever made the changes to the ROM.
		* Description is exactly what it says on the tin: Describe how the ROM will be different after applying this mod.
		* Version is a string differentiating _this_ build of the mod that may have been made.  There's no rules for this, just try to ensure it makes logical sense.
		* Dependencies are a semi-colon separated list of the IDs of mods that need to be applied before or after this one.  Unless you're making a mod of another mod (and the mod was applied to the source ROM to which you've browsed), leave these blank.
  	 D. Choose additional mod creation options.
		* Enable Adds will add any file that's in the modified ROM but not the source ROM to the mod in its entirety.  Leave this checked if you want to add files to the ROM.
		* Enable Deletes will delete any file from a ROM if it's in the source ROM but not the modified ROM.  Leave this unchecked unless you really want to delete files from the ROM.
  	 E. Click Create, and wait for the dialog to go away.
 5. Create the modpack.  There is currently no GUI to do this, so you'll have to do things yourself.
	 A. Close the form.
	 B. Browse to the directory the program is in.
	 C. Open "Tools".
	 D. Delete the following folders if the exist: 
		* dstemp
		* modstemp
	 E. Go back to the directory the program is in.
	 F. Create a new zip file containing all the files and directories within.  To keep things standard, *only* use a zip file, because external programs may apply this modpack.  It is against the license of this program to use other archive formats without explicit written permission.
	
## System requirements
* .Net Framework 4.6

## Planned Features:
* Easier-to-use UI for creating modpacks.
* Patch collision detection to warn the user of conflicting mods before attempting to apply them.
* Patcher pack creation UI.
