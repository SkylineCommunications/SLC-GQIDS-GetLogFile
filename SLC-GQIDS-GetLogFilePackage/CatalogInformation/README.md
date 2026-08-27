# Get Log File

## About

**Get Log File** is a GQI ad hoc data source that retrieves the contents of a DataMiner log file and exposes each line as a row in a GQI query result. It can be used in dashboards or low-code apps to visualize, search, and filter live log data without having to leave the DataMiner web interface.

The data source supports both **element log files** and **DataMiner system log files**. When targeting a log file on a remote DataMiner Agent (i.e., an Agent other than the one you are connected to), pass the **DMA ID** input argument to make sure the request is routed correctly.

## Key Features

- **Line-by-line output** — Returns each log line as an individual row with a `Line Number` and `Data` column, making it straightforward to filter, sort, or aggregate log content in a GQI query.
- **Element and system log support** — Works with both element-level logs and DataMiner system logs from any Agent in the cluster.
- **Automatic DMA ID resolution** — When no DMA ID is passed, the data source attempts to resolve the hosting agent automatically by looking up the element name, so simple single-agent queries require no extra configuration.
- **DataMiner Assistant integration** — Can be referenced in the DataMiner Assistant context to enable natural-language log retrieval.

## Prerequisites

- DataMiner version **10.4.0.0 – 14003** or higher.

## Technical Reference

### Input Arguments

| Argument | Type | Required | Description |
|---|---|---|---|
| Log File Name | String | Yes | The name of the log file to be retrieved (i.e., an element name or a system log file name). |
| DMA ID | Int | No | The DataMiner ID of the Agent that hosts the log file. Required when targeting a remote DMA or a system log file on a specific Agent. Leave empty for element log files when auto-resolution is sufficient. |

### Output Columns

| Column | Type | Description |
|---|---|---|
| Line Number | Int | 1-based index of the line within the log file. |
| Data | String | The text of the log line. |
