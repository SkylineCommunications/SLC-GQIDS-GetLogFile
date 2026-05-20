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
    example: "SLNet"
  - name: "DMA ID"
    type: "Int32"
    description: "The DataMiner Agent ID to retrieve the log file from. Only needed when requesting DataMiner system log files. Leave default (0) when requesting element log files."
    example: "123"
---

# Get Log File Data Source

This data source retrieves the contents of a DataMiner log file and returns it line by line. Each row represents a single line from the log file, along with its line number.

## Usage

For retrieving element log files, simply provide the element name as the log file name (e.g., "ElementName"). 
For system log files, provide the appropriate log file name (e.g., "SLNet") and specify the DMA ID if needed. 
There is no need to include the ".txt" extension in the log file name. The data source will handle both types of log files based on the provided arguments.

For most system log files, the log file exists from before the last DataMiner restart. To get this previous file, simply add _BAK to the file name.

Commonly used System log files are:
* SLCassandraDriver
* SLCassandraHealth
* SLCassandraMigration
* SLCcaEndpointManager
* SLClient
* SLClosedLogWrites
* SLCloudFeedManager
* SLClusterEndpointsManager
* SLClusterManager
* SLClusterTransitionStateManager
* SLConfigurationManager
* SLConnectivity
* SLCorrelation
* SLCorrelationAnalyzer
* SLDataApiManager
* SLDataGateway
* SLDataGatewayObservability
* SLDataMiner
* SLDBConnection
* SLDBMigration
* SLDirectViewSubscriptionManager
* SLDMS
* SLDocumentIntelligenceManager
* SLElement
* SLElementInProtocol
* SLErrors
* SLErrorsInProtocol
* SLEventCache
* SLFailover
* SLFailoverProxyManager
* SLFailoverScriptManager
* SLFileInfoManager
* SLFunctionManager
* SLHangingCalls
* SLHelper
* SLHelperWrapper
* SLHistoryManager
* SLIncrementManager
* SLJobManager
* SLLegacyPipeConnection
* SLManagedScripting
* SLManagerStore
* SLMasterSyncerManager
* SLMediationSnippetInfo
* SLMigrationManager
* SLModelHostManager
* SLModuleSettingsManager
* SLNet.Repositories.Security
* SLNet
* SLNet0
* SLNet1
* SLNet2
* SLNetConnectionsMonitor
* SLNetObservability
* SLNotifications
* SLPhotosManager
* SLPort
* SLPortSplit
* SLProcessAutomationManager
* SLProfileManager
* SLProtobufSerialization
* SLProtocol
* SLReportsAndDashboardsManager
* SLRepositoryRequests
* SLResourceManager
* SLResourceManagerAutomation
* SLResourceManagerScheduler
* SLResourceManagerStorage
* SLScheduler
* SLSearch
* SLServiceManager
* SLSharingManager
* SLSiteManager
* SLSlowClientMessages
* SLSmartBaselineManager
* SLSNMPAgent
* SLSNMPManager
* SLSpectrum
* SLSpectrumManager
* SLSQLiteDriver
* SLSRMSettableServiceStateManager
* SLSsh
* SLSubscriptionLog
* sltaskbarutility.update.log
* SLTopologyItemHostingCacheManager
* SLTransactionLog
* SLUserDefinableApiManager
* SLVisualManager
* SLWatchDog
* SLWatchdog2
* SLWatchDogClient
* SLXML