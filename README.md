# SLC-GQIDS-GetLogFile

This repository contains a Skyline DataMiner SDK solution with:

- A **GQI Ad Hoc Data Source** that retrieves DataMiner log file content line by line.
- A **DataMiner Package project** that bundles and installs the data source and setup content.

## Projects

| Project | Type | Description |
|---|---|---|
| [`SLC-GQIDS-GetLogFile`](./SLC-GQIDS-GetLogFile/README.md) | AdHocDataSource | GQI data source named **Get Log File** that fetches a DataMiner log file and returns rows with line number and text. |
| [`SLC-GQIDS-GetLogFilePackage`](./SLC-GQIDS-GetLogFilePackage/README.md) | Package | DataMiner package project that installs default package content and copies `Get Log File.md` into the DataMiner Assistant custom adhoc context folder. |
