# Get Log File

## About

**Get Log File** is a GQI ad hoc data source that retrieves the contents of a DataMiner log file and exposes each line as a row in a GQI query result. Use it in dashboards or low-code apps to visualize, search, and filter live log data without leaving the DataMiner web interface.

The data source supports both **element log files** and **DataMiner system log files**. When targeting a log file on a remote DataMiner Agent (i.e. a DMA other than the one you are connected to), supply the **DMA ID** input argument to route the request correctly.

## Key Features

- **Line-by-line output** — returns each log line as an individual row with a `Line Number` and `Data` column, making it straightforward to filter, sort, or aggregate log content in a GQI query.
- **Element and system log support** — works with both element-level logs and DataMiner system logs from any agent in the cluster.
- **Automatic DMA ID resolution** — when no DMA ID is supplied, the data source attempts to resolve the hosting agent automatically by looking up the element name, so simple single-agent queries require no extra configuration.
- **DataMiner Copilot integration** — can be referenced in the AI assistant context to enable natural-language log retrieval.

## Prerequisites

- DataMiner version **10.4.0.0 – 14003** or higher (minimum required version).

## Technical Reference

### Input Arguments

| Argument | Type | Required | Description |
|---|---|---|---|
| Log File Name | String | Yes | The name of the log file to retrieve (e.g. an element name or a system log file name). |
| DMA ID | Int | No | The DataMiner ID of the agent that hosts the log file. Required when targeting a remote DMA or a system log file on a specific agent. Leave empty for element log files when auto-resolution is sufficient. |

### Output Columns

| Column | Type | Description |
|---|---|---|
| Line Number | Int | 1-based index of the line within the log file. |
| Data | String | The text content of the log line. |

