# fountainpen Notepad++ Plugin

This repo contains code for a benignware (pseudo malware) plugin for the Notepad++ editor based on this [plugin template](https://github.com/kbilsted/NotepadPlusPlusPluginPack.Net)

The plugin purports to be an AutoSave feature, but in fact it exfiltrates the code to a webserver that you specify. This code was designed as a way to test detection capabilities.

[This article](https://pentestlab.blog/2022/02/14/persistence-notepad-plugins/) was also used as a reference for this work.

## Geting Started

### Prerequisites

Ensure that Notepad++ is installed in your environment.  This plugin was tested with the amd64 version of [Notepad++ v8.2.1](https://github.com/notepad-plus-plus/notepad-plus-plus/releases/download/v8.2.1/npp.8.2.1.Installer.x64.exe).

### Installation

Run the [fountainpen installer](bin/setup_fountainpen.exe)

### Configuration

Edit the host, port, path, and keywords values in the fountainpen.ini file as needed.


## Release

Rollerball is released under a Apache-2.0 license. See [LICENSE](LICENSE) for details.

LLNL-CODE-842428
