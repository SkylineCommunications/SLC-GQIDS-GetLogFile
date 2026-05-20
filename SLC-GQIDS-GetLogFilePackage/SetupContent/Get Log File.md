---
name: "Get Log File"
description: "Retrieve the contents of a DataMiner log file, returning each line with its line number. Both element log files and DMA system log files are supported."
columns:
  - name: "Line Number"
    type: "Int32"
    description: "The line number of the log file entry."
  - name: "Data"
    type: "String"
    description: "The text content of the log file line."
inputArguments:
  - name: "Log File Name"
    type: "String"
    description: "The name of the log file to retrieve."
    example: "SLNet.txt"
  - name: "DMA ID"
    type: "Int32"
    description: "The DataMiner Agent ID to retrieve the log file from. Only needed when requesting DataMiner system log files. Leave default (0) when requesting element log files."
    example: "123"
---

# Get Log File Data Source

This data source retrieves the contents of a DataMiner log file and returns it line by line. Each row represents a single line from the log file, along with its line number.

## Usage

Provide the log file name and optionally the DMA ID to retrieve log files from a specific DataMiner Agent. If the DMA ID is not specified or set to 0, the request targets the local agent.