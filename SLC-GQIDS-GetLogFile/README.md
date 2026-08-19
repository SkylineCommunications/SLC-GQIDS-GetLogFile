# SLC-GQIDS-GetLogFile

## Overview

`SLC-GQIDS-GetLogFile` is a Skyline DataMiner SDK **AdHocDataSource** project.
It exposes a GQI data source named **Get Log File** that reads a log file from DataMiner and returns its content as tabular rows.

## GQI Data Source

- **Name**: `Get Log File`
- **Class**: `SLCGQIDSGetLogFile`
- **Interfaces**: `IGQIDataSource`, `IGQIOnInit`, `IGQIInputArguments`

### Input Arguments

- `Log File Name` (string, required): Name of the log file to retrieve.
- `DMA ID` (int, optional): DMA ID to target for system log files.  
  If omitted (`0`), the data source attempts to resolve the hosting agent by looking up an element with the provided name.

### Output Columns

- `Line Number` (int)
- `Data` (string)

Each output row corresponds to one line in the retrieved log file content.

## Build

This project targets **.NET Framework 4.8** and uses `Skyline.DataMiner.Sdk`.
