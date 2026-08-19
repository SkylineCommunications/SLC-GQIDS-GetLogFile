# SLC-GQIDS-GetLogFilePackage

## Overview

`SLC-GQIDS-GetLogFilePackage` is a Skyline DataMiner SDK **Package** project.
It generates a DataMiner application package (`.dmapp`) and includes installation logic for deploying bundled content.

## Package Content

The project contains standard package folders such as:

- `PackageContent/` (including project and catalog references)
- `SetupContent/` (includes `Get Log File.md`)
- `CatalogInformation/` metadata files

## Installation Behavior

During package installation (`InstallAppPackage` entry point), the installer:

1. Installs default package content.
2. Resolves the setup content directory.
3. Ensures the destination folder exists:
   `C:\ProgramData\Skyline Communications\DataMiner Assistant\Synced Documents\Context\Custom\adhoc`
4. Copies `Get Log File.md` from setup content into that destination.

## Build

This project targets **.NET Framework 4.8**, uses `Skyline.DataMiner.Sdk`, and has package generation enabled.