using Skyline.DataMiner.Analytics.GenericInterface;
using Skyline.DataMiner.Net.Helper;
using Skyline.DataMiner.Net.Messages;
using System;
using System.Collections.Generic;

namespace SLCGQIDSGetLogFile
{
    /// <summary>
    /// Represents a data source.
    /// See: https://aka.dataminer.services/gqi-external-data-source for a complete example.
    /// </summary>
    [GQIMetaData(Name = "Get Log File")]
    public sealed class SLCGQIDSGetLogFile : IGQIDataSource
        , IGQIOnInit
        , IGQIInputArguments
    {
        private GQIDMS _dms;

        public OnInitOutputArgs OnInit(OnInitInputArgs args)
        {
            _dms = args.DMS;
            return default;
        }

        private readonly GQIStringArgument _fileNameArg = new GQIStringArgument("Log File Name") { IsRequired = true };
        private readonly GQIIntArgument _dmaIdArg = new GQIIntArgument("DMA ID") { IsRequired = false }; //not needed when requesing element log files, only needed when requesting DM system log files

        private string _fileName;
        private int _dmaId;

        public GQIArgument[] GetInputArguments()
        {
            return new GQIArgument[]
            {
                _fileNameArg,
                _dmaIdArg
            };
        }

        public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
        {
            _fileName = args.GetArgumentValue(_fileNameArg);
            _dmaId = args.GetArgumentValue(_dmaIdArg);
            return default;
        }

        public GQIColumn[] GetColumns()
        {
            return new GQIColumn[]
            {
                new GQIIntColumn("Line Number"),
                new GQIStringColumn("Data"),
            };
        }

        public GQIPage GetNextPage(GetNextPageInputArgs args)
        {
            int dmaId = _dmaId;

            if (dmaId == 0)
            {
                // Try to resolve the DMA ID by looking up an element with the log file name
                try
                {
                    var getElementMsg = new GetElementByNameMessage(_fileName);
                    var elementResponse = _dms.SendMessage(getElementMsg) as ElementInfoEventMessage;

                    if (elementResponse != null)
                    {
                        dmaId = elementResponse.HostingAgentID;
                    }
                }
                catch
                {
                    dmaId = -1;
                }
            }

            var logFileRequest = new GetLogTextFileStringContentRequestMessage(_fileName) { LogFileType = Skyline.DataMiner.Net.Info.LogFileType.Core, DataMinerID = dmaId, HostingDataMinerID = dmaId };

            var logFileResponse = _dms.SendMessage(logFileRequest) as GetLogTextFileStringContentResponseMessage;

            var rows = new List<GQIRow>();

            if (logFileResponse?.Content != null)
            {
                var lines = logFileResponse.Content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                for (int i = 0; i < lines.Length; i++)
                {
                    var cells = new[]
                    {
                        new GQICell { Value = i + 1 },
                        new GQICell { Value = lines[i] },
                    };

                    rows.Add(new GQIRow(cells));
                }
            }

            return new GQIPage(rows.ToArray())
            {
                HasNextPage = false,
            };
        }
    }
}
